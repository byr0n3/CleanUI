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
	public sealed partial class Combobox<TValue, TOption, TOptionValue> : InputBase<TValue>, IAsyncDisposable
	{
		[Inject] public required IJSRuntime Js { get; init; }

		[Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();

		[Parameter] [EditorRequired] public required TOption[] Options { get; set; }

		[Parameter] [EditorRequired] public required Func<TOption, TOptionValue> GetOptionValue { get; set; }

		[Parameter] [EditorRequired] public required Func<TOption, string> GetOptionLabel { get; set; }

		[Parameter] public Func<TOption, RenderFragment?>? GetOptionIcon { get; set; }

		[Parameter] public string? Search { get; set; }

		[Parameter] public EventCallback<string?> SearchChanged { get; set; }

		[Parameter] public Expression<Func<string?>>? SearchExpression { get; set; }

		[Parameter] public TimeSpan SearchDelay { get; set; } = Debounce.DefaultDelay;

		[Parameter] public Func<TOption[], RenderFragment>? FormatLabel { get; set; }

		[Parameter] public string Placeholder { get; set; } = "Select…";

		[Parameter] public string? ContainerClass { get; set; }

		[Parameter] public RenderFragment? PrefixContent { get; set; }

		[Parameter] public RenderFragment? ChildContent { get; set; }

		private string PopoverId =>
			$"{this.Id}-popover";

		private bool searching;
		private IJSObjectReference? module;
		private Func<ChangeEventArgs, Task> debouncedSearch = null!;

		protected override void OnInitialized() =>
			this.debouncedSearch = Debounce.Create<ChangeEventArgs>((args) => this.InvokeAsync(() => this.SearchAsync(args)),
																	this.SearchDelay);

		protected override Task OnAfterRenderAsync(bool firstRender) =>
			firstRender ? this.InitializeKeyboardAsync() : Task.CompletedTask;

		private async Task InitializeKeyboardAsync()
		{
			this.module ??= await this.Js.InvokeAsync<IJSObjectReference>("import", this.Assets["/_content/CleanUI/combobox.js"]);

			await this.module.InvokeVoidAsync("comboboxInitializeKeyboard", this.Id, this.PopoverId);
		}

		private RenderFragment GetButtonLabel()
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

		private IEnumerable<TOption> GetSelectedOptions() =>
			this.Options.Where(this.IsOptionSelected);

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

		private Task UpdateValueAsync(TOptionValue optionValue)
		{
			if (this.Value is TOptionValue[] array)
			{
				var idx = array.IndexOf(optionValue, EqualityComparer<TOptionValue>.Default);

				if (idx != -1)
				{
					(array[idx], array[^1]) = (array[^1], array[idx]);

					Array.Resize(ref array, array.Length - 1);
				}
				else
				{
					Array.Resize(ref array, array.Length + 1);

					array[^1] = optionValue;
				}

				// @todo Illegal casting
				return this.ValueChanged.InvokeAsync((TValue)(object)array);
			}

			if (optionValue is TValue value)
			{
				var selected = EqualityComparer<TValue>.Default.Equals(this.Value, value);

				return this.ValueChanged.InvokeAsync(selected ? default : value);
			}

			throw new Exception($"Unknown type comparision scenario: {typeof(TValue)}–{typeof(TOptionValue)}");
		}

		protected override bool TryParseValueFromString(string? value,
														[MaybeNullWhen(false)] out TValue result,
														[NotNullWhen(false)] out string? validationErrorMessage)
		{
			result = default;
			validationErrorMessage = "";
			return false;
		}

		public ValueTask DisposeAsync() =>
			this.module?.DisposeAsync() ?? ValueTask.CompletedTask;
	}
}
