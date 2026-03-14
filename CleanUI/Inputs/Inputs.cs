using System;
using System.Collections.Generic;
using System.Numerics;
using CleanUI.Internal.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace CleanUI
{
	/// <inheritdoc cref="InputText"/>
	public sealed class CleanInputText : CleanInputBase<string?, InputText>;

	/// <inheritdoc cref="InputNumber{TValue}"/>
	public sealed class CleanInputNumber<TValue> : CleanInputBase<TValue, InputNumber<TValue>>
		where TValue : INumber<TValue>;

	/// <inheritdoc cref="InputDate{TValue}"/>
	public sealed class CleanInputDate<TValue> : CleanInputBase<TValue, InputDate<TValue>>
	{
		/// <inheritdoc cref="InputDate{TValue}.Type"/>
		[Parameter]
		public InputDateType Type { get; set; } = InputDateType.Date;

		protected override Dictionary<string, object> ComponentParameters =>
			new(StringComparer.Ordinal)
			{
				[nameof(InputDate<>.Type)] = this.Type,
			};
	}

	/// <inheritdoc cref="InputTextArea"/>
	public sealed class CleanInputTextArea : CleanInputBase<string?, InputTextArea>;

	/// <inheritdoc cref="InputFile"/>
	public sealed class CleanInputFile : InputFile
	{
		/// <inheritdoc/>
		protected override void OnParametersSet()
		{
			var parameters = this.AdditionalAttributes ?? new Dictionary<string, object>(StringComparer.Ordinal);

			parameters["class"] = $"input {parameters.GetString("class")}";

			this.AdditionalAttributes = parameters;
		}
	}

	/// <inheritdoc cref="InputRadio{TValue}" />
	public sealed class CleanInputRadio<TValue> : CleanComponentBase
	{
		/// <inheritdoc cref="InputRadio{TValue}.Value" />
		[Parameter]
		public TValue? Value { get; set; }

		/// <inheritdoc cref="InputRadio{TValue}.Name" />
		[Parameter]
		public string? Name { get; set; }

		/// <summary>
		/// The content of the label of the radio input.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		/// <inheritdoc />
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "label");
			{
				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddAttribute(2, "class", $"radio-container {this.AdditionalAttributes.GetString("class")}");

				builder.OpenComponent<InputRadio<TValue>>(2);
				{
					builder.AddComponentParameter(3, nameof(InputRadio<>.Value), this.Value);
					builder.AddComponentParameter(4, nameof(InputRadio<>.Name), this.Name);
					builder.AddAttribute(5, "class", "input");
				}
				builder.CloseComponent();

				if (this.ChildContent is not null)
				{
					builder.AddContent(6, this.ChildContent);
				}
			}
			builder.CloseElement();
		}
	}

	/// <inheritdoc cref="InputRadioGroup{TValue}" />
	public sealed class CleanInputRadioGroup<TValue> : InputRadioGroup<TValue>
	{
		/// <summary>
		/// Whether to display the child options in a vertical/block layout, instead of horizontal/inline.
		/// </summary>
		[Parameter] public bool Vertical { get; set; }

		/// <inheritdoc />
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "div");
			{
				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddAttribute(2, "class", $"radio-group {(this.Vertical ? "radio-group-vertical" : "")} {this.AdditionalAttributes.GetString("class")}");

				base.BuildRenderTree(builder);
			}
			builder.CloseElement();
		}
	}
}
