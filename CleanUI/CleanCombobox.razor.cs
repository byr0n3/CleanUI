using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CleanUI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace CleanUI
{
	/// <summary>
	/// An input widget that has an associated popup.
	/// </summary>
	/// <typeparam name="TValue">The value the component returns/manages.</typeparam>
	/// <typeparam name="TOption">The type of the options to display.</typeparam>
	/// <typeparam name="TOptionValue">
	/// The type of the value of an option.
	/// <p>This type parameter should be the same as <typeparamref name="TValue"/> if it's NOT an array type, or equal to the type of the entries in the array if it is.</p>
	/// </typeparam>
	public sealed partial class CleanCombobox<TValue, TOption, TOptionValue> : InputBase<TValue>, IAsyncDisposable
	{
		/// <inheritdoc cref="IJSRuntime" />
		[Inject]
		public required IJSRuntime Js { get; init; }

		/// <summary>
		/// The ID of the combobox.
		/// </summary>
		[Parameter]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		/// <summary>
		/// The options to display in the combobox.
		/// </summary>
		[Parameter]
		[EditorRequired]
		public required TOption[] Options { get; set; }

		/// <summary>
		/// Delegate that returns the according <see cref="TValue"/> instance of the option.
		/// </summary>
		[Parameter]
		[EditorRequired]
		public required Func<TOption, TOptionValue> GetOptionValue { get; set; }

		/// <summary>
		/// Delegate that returns the according label content of the option.
		/// </summary>
		[Parameter]
		[EditorRequired]
		public required Func<TOption, string> GetOptionLabel { get; set; }

		/// <summary>
		/// Delegate that optionally returns the according icon content of the option.
		/// </summary>
		[Parameter]
		public Func<TOption, RenderFragment?>? GetOptionIcon { get; set; }

		/// <summary>
		/// Gets or sets the current search input.
		/// </summary>
		[Parameter]
		public string? Search { get; set; }

		/// <summary>
		/// Gets or sets a callback that updates the search input.
		/// </summary>
		[Parameter]
		public EventCallback<string?> SearchChanged { get; set; }

		/// <summary>
		/// Gets or sets an expression that identifies the search input.
		/// </summary>
		[Parameter]
		public Expression<Func<string?>>? SearchExpression { get; set; }

		/// <summary>
		/// The minimum amount of time between inputs before triggering the <see cref="SearchChanged"/> callback.
		/// </summary>
		/// <remarks>
		/// Keep this value reasonably short in a way where the user can't trigger too many <see cref="SearchChanged"/> invokations,
		/// while also still feeling natural and fast.
		/// </remarks>
		[Parameter]
		public TimeSpan SearchDelay { get; set; } = Debounce.DefaultDelay;

		/// <summary>
		/// Gets or sets a method that formats the displayed value of the button.
		/// </summary>
		[Parameter]
		public Func<TOption[], RenderFragment>? FormatLabel { get; set; }

		/// <summary>
		/// Gets or sets the placeholder to show in the button when no value was selected.
		/// </summary>
		[Parameter]
		public string Placeholder { get; set; } = "Select…";

		/// <inheritdoc cref="CleanInputBase{TValue, TInput}.ContainerClass" />
		[Parameter]
		public string? ContainerClass { get; set; }

		/// <inheritdoc cref="CleanButton.PrefixContent" />
		[Parameter]
		public RenderFragment? PrefixContent { get; set; }

		/// <summary>
		/// The content of the button.
		/// </summary>
		/// <remarks>This overrides the placeholder when no value was selected.</remarks>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		/// <summary>
		/// The ID of the popover element, based on the <see cref="Id"/> parameter.
		/// </summary>
		private string PopoverId =>
			$"{this.Id}-popover";

		private bool searching;
		private IJSObjectReference? module;
		private Func<ChangeEventArgs, Task> debouncedSearch = null!;

		/// <inheritdoc/>
		protected override void OnInitialized() =>
			this.debouncedSearch = Debounce.Create<ChangeEventArgs>((args) => this.InvokeAsync(() => this.SearchAsync(args)),
																	this.SearchDelay);

		/// <inheritdoc/>
		protected override Task OnAfterRenderAsync(bool firstRender) =>
			firstRender ? this.InitializeKeyboardAsync() : Task.CompletedTask;

		/// <summary>
		/// Initializes the keyboard shortcut handlers for the combobox and its options.
		/// </summary>
		private async Task InitializeKeyboardAsync()
		{
			this.module ??= await this.Js.InvokeAsync<IJSObjectReference>("import", this.Assets["/_content/CleanUI/combobox.js"]);

			await this.module.InvokeVoidAsync("comboboxInitializeKeyboard", this.Id, this.PopoverId);
		}

		/// <summary>
		/// Returns the content to display in the button element.
		/// </summary>
		/// <returns>The content to display in the button.</returns>
		private RenderFragment GetButtonContent()
		{
			var selected = this.GetSelectedOptions().ToArray();

			if (this.FormatLabel is not null)
			{
				return this.FormatLabel(selected);
			}

			return (selected.Length) switch
			{
				0 => (builder) =>
				{
					if (this.ChildContent is not null)
					{
						builder.AddContent(0, this.ChildContent);
					}
					else
					{
						builder.AddContent(1, this.Placeholder);
					}
				},
				1 => (builder) =>
				{
					var option = selected[0];

					builder.AddContent(0, this.GetOptionLabel.Invoke(option));
				},
				_ => (builder) => builder.AddContent(0, string.Join(", ", selected.Select(this.GetOptionLabel))),
			};
		}

		/// <summary>
		/// Callback to call when the user inputs a value in the search box.
		/// </summary>
		/// <param name="args">The event arguments of the <c>oninput</c> event.</param>
		/// <returns>A <see cref="Task"/> that completes when the search input was updated.</returns>
		private async Task SearchAsync(ChangeEventArgs args)
		{
			if (!this.SearchChanged.HasDelegate || (args.Value is not string @string))
			{
				return;
			}

			this.searching = true;

			await this.SearchChanged.InvokeAsync(@string);

			// Clear the current value(s) if it isn't there anymore.
			if (this.Value is TOptionValue[] array)
			{
				var next = array.Where((value) => this.Options.Select(this.GetOptionValue).Contains(value)).ToArray();

				// @todo Illegal casting
				await this.ValueChanged.InvokeAsync((TValue)(object)next);
			}
			else if (this.Value is TOptionValue value && !this.Options.Select(this.GetOptionValue).Contains(value))
			{
				await this.ValueChanged.InvokeAsync();
			}

			this.searching = false;
		}

		/// <summary>
		/// Returns the currently selected options.
		/// </summary>
		/// <returns><see cref="IEnumerable{T}"/> of option instances that are currently selected.</returns>
		private IEnumerable<TOption> GetSelectedOptions() =>
			this.Options.Where(this.IsOptionSelected);

		/// <summary>
		/// Returns whether an option is currently selected.
		/// </summary>
		/// <param name="option">The option to check if it is selected.</param>
		/// <returns><see langword="true"/> when the option is currently selected, <see langword="false"/> otherwise.</returns>
		/// <exception cref="Exception">Thrown when <see cref="InputBase{TValue}.Value"/> is of an unexpected type.</exception>
		private bool IsOptionSelected(TOption option)
		{
			if (this.Value is null)
			{
				return false;
			}

			var optionValue = this.GetOptionValue(option);

			if (optionValue is null)
			{
				return false;
			}

			return (this.Value) switch
			{
				TOptionValue[] array => array.Contains(optionValue),
				TOptionValue value   => EqualityComparer<TOptionValue>.Default.Equals(value, optionValue),
				_                    => throw new Exception($"Unknown type comparision scenario: {typeof(TValue)}–{typeof(TOptionValue)}"),
			};
		}

		/// <summary>
		/// Callback for when a user clicks on an option, setting it as the current value,
		/// or toggling it if <see cref="InputBase{TValue}.Value"/> is an array type.
		/// </summary>
		/// <param name="option">The option to set or toggle.</param>
		/// <returns>A <see cref="Task"/> that completes when the current value was updated.</returns>
		/// <exception cref="Exception">Thrown when <see cref="InputBase{TValue}.Value"/> is of an unexpected type.</exception>
		private Task UpdateValueAsync(TOptionValue option)
		{
			if (this.Value is TOptionValue[] array)
			{
				var idx = array.IndexOf(option, EqualityComparer<TOptionValue>.Default);

				if (idx != -1)
				{
					(array[idx], array[^1]) = (array[^1], array[idx]);

					Array.Resize(ref array, array.Length - 1);
				}
				else
				{
					Array.Resize(ref array, array.Length + 1);

					array[^1] = option;
				}

				// @todo Illegal casting
				return this.ValueChanged.InvokeAsync((TValue)(object)array);
			}

			if (option is TValue value)
			{
				var selected = EqualityComparer<TValue>.Default.Equals(this.Value, value);

				return this.ValueChanged.InvokeAsync(selected ? default : value);
			}

			throw new Exception($"Unknown type comparision scenario: {typeof(TValue)}–{typeof(TOptionValue)}");
		}

		/// <inheritdoc/>
		protected override bool TryParseValueFromString(string? value,
														[MaybeNullWhen(false)] out TValue result,
														[NotNullWhen(false)] out string? validationErrorMessage)
		{
			result = default;
			validationErrorMessage = "";
			return false;
		}

		/// <inheritdoc/>
		public ValueTask DisposeAsync() =>
			this.module?.DisposeAsync() ?? ValueTask.CompletedTask;
	}
}
