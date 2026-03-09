using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using CleanUI.Internal.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace CleanUI
{
	/// <inheritdoc cref="InputSelect{TValue}"/>
	/// <typeparam name="TValue">The value the component returns/manages.</typeparam>
	/// <typeparam name="TOption">The type of the options to display.</typeparam>
	public sealed class Select<TValue, TOption> : InputSelect<TValue>
	{
		/// <summary>
		/// The options that are selectable.
		/// </summary>
		/// <remarks>
		/// <p>This parameter will override the <see cref="Select{TValue, TOption}.ChildContent"/> parameter.</p>
		/// <p>For this to work, the <see cref="GetOptionValue"/> and <see cref="GetOptionLabel"/> parameters need to be set.</p>
		/// </remarks>
		[Parameter]
		public TOption[]? Options { get; set; }

		/// <summary>
		/// Delegate that returns the according <see cref="TValue"/> instance of the option.
		/// </summary>
		/// <remarks>This property is required when the <see cref="Options"/> parameter is set and can be null when it isn't.</remarks>
		[Parameter]
		public Func<TOption, TValue>? GetOptionValue { get; set; }

		/// <summary>
		/// Delegate that returns the according label content of the option.
		/// </summary>
		/// <remarks>This property is required when the <see cref="Options"/> parameter is set and can be null when it isn't.</remarks>
		[Parameter]
		public Func<TOption, string>? GetOptionLabel { get; set; }

		/// <summary>
		/// Delegate that returns the according icon content of the option.
		/// </summary>
		/// <remarks>This parameter only works when the <see cref="Options"/> parameter is set to a non-null value.</remarks>
		[Parameter]
		public Func<TOption, RenderFragment?>? GetOptionIcon { get; set; }

		/// <summary>
		/// Whether to add an empty <see langword="null"/> option to the available options.
		/// </summary>
		/// <remarks>This parameter only works when the <see cref="Options"/> parameter is set to a non-null value.</remarks>
		[Parameter]
		public bool AddNullOption { get; set; }

		/// <summary>
		/// The label of the empty <see langword="null"/> option. This defaults to an empty string.
		/// </summary>
		/// <remarks>
		/// This parameter only works when the <see cref="Options"/> parameter is set to a non-null value <b>AND</b>
		/// if the <see cref="AddNullOption"/> parameter is set to <see langword="true"/>.
		/// </remarks>
		[Parameter]
		public string NullOptionLabel { get; set; } = "";

		/// <summary>
		/// The icon of the empty <see langword="null"/> option.
		/// </summary>
		/// <remarks>
		/// This parameter only works when the <see cref="Options"/> parameter is set to a non-null value <b>AND</b>
		/// if the <see cref="AddNullOption"/> parameter is set to <see langword="true"/>.
		/// </remarks>
		[Parameter]
		public RenderFragment? NullOptionIcon { get; set; }

		/// <summary>
		/// Whether this component has it's options-related parameters configured.
		/// </summary>
		private bool HasOptions
		{
			[MemberNotNullWhen(true, nameof(Select<,>.Options), nameof(Select<,>.GetOptionValue), nameof(Select<,>.GetOptionLabel))]
			get => (this.Options is not null) && (this.GetOptionValue is not null) && (this.GetOptionLabel is not null);
		}

		/// <summary>
		/// Whether this component has a <see cref="GetOptionIcon"/> parameter configured.
		/// </summary>
		private bool OptionsHaveIcons
		{
			[MemberNotNullWhen(true, nameof(Select<,>.GetOptionIcon))]
			get => this.GetOptionIcon is not null;
		}

		/// <inheritdoc/>
		protected override void OnParametersSet()
		{
			if (this.HasOptions)
			{
				this.ChildContent = (RenderFragment)this.GetSelectContent;
			}

			var parameters = (IDictionary<string, object>?)this.AdditionalAttributes ??
							 new Dictionary<string, object>(StringComparer.Ordinal);

			parameters["class"] = $"select {parameters.GetString("class")}";

			this.AdditionalAttributes = parameters.AsReadOnly();
		}

		/// <summary>
		/// Appends the configured options to the select content.
		/// </summary>
		/// <param name="builder">The builder to add the options to.</param>
		private void GetSelectContent(RenderTreeBuilder builder)
		{
			Debug.Assert(this.HasOptions);

			builder.OpenElement(0, "button");
			{
				builder.AddAttribute(1, "type", "button");
				builder.AddContent(2, (RenderFragment)(static (buttonBuilder) =>
				{
					buttonBuilder.OpenElement(3, "selectedcontent");
					buttonBuilder.CloseElement();
				}));
			}
			builder.CloseElement();

			if (this.AddNullOption)
			{
				AddOption(builder,
						  default,
						  this.NullOptionLabel,
						  this.OptionsHaveIcons ? this.NullOptionIcon ?? RenderFragment.Empty : null);
			}

			foreach (var option in this.Options)
			{
				var value = this.GetOptionValue(option);
				var label = this.GetOptionLabel(option);
				var icon = this.OptionsHaveIcons ? this.GetOptionIcon.Invoke(option) ?? RenderFragment.Empty : null;

				AddOption(builder, value, label, icon);
			}

			return;

			static void AddOption(RenderTreeBuilder builder, TValue? value, string label, RenderFragment? icon)
			{
				builder.OpenElement(0, "option");
				{
					builder.AddAttribute(1, "value", value);

					if (icon is not null)
					{
						builder.OpenElement(2, "span");
						{
							builder.AddAttribute(3, "class", "select-option-icon");
							builder.AddAttribute(4, "aria-hidden", "true");
							builder.AddContent(5, icon);
						}
						builder.CloseElement();
					}

					builder.OpenElement(6, "span");
					{
						builder.AddAttribute(7, "class", "select-option-label");
						builder.AddContent(8, label);
					}
					builder.CloseElement();
				}
				builder.CloseElement();
			}
		}
	}
}
