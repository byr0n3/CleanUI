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
	public class CleanInputText : CleanInputBase<string?, InputText>;

	/// <inheritdoc cref="InputNumber{TValue}"/>
	public class CleanInputNumber<TValue> : CleanInputBase<TValue, InputNumber<TValue>>
		where TValue : INumber<TValue>;

	/// <inheritdoc cref="InputDate{TValue}"/>
	public class CleanInputDate<TValue> : CleanInputBase<TValue, InputDate<TValue>>
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
	public class CleanInputTextArea : CleanInputBase<string?, InputTextArea>;

	/// <inheritdoc cref="InputFile"/>
	public class CleanInputFile : InputFile
	{
		/// <inheritdoc cref="ComponentBase.OnParametersSet" />
		protected override void OnParametersSet()
		{
			var parameters = this.AdditionalAttributes ?? new Dictionary<string, object>(StringComparer.Ordinal);

			parameters["class"] = $"input {parameters.GetString("class")}";

			this.AdditionalAttributes = parameters;
		}
	}

	public class CleanInputCheckbox : InputCheckbox
	{
		/// <inheritdoc cref="CleanInputBase{TValue, TInput}.ContainerClass" />
		[Parameter]
		public string? ContainerClass { get; set; }

		/// <summary>
		/// The label content to show for the checkbox.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		protected override void OnParametersSet()
		{
			var parameters = (IDictionary<string, object>?)this.AdditionalAttributes ??
							 new Dictionary<string, object>(StringComparer.Ordinal);

			parameters["class"] = $"input {parameters.GetString("class")}";

			this.AdditionalAttributes = parameters.AsReadOnly();
		}

		/// <inheritdoc cref="ComponentBase.BuildRenderTree" />
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "label");
			{
				builder.AddAttribute(1, "class", $"checkbox-container {this.ContainerClass}");

				base.BuildRenderTree(builder);

				builder.AddContent(2, this.ChildContent);
			}
			builder.CloseElement();
		}
	}

	/// <inheritdoc cref="InputRadio{TValue}" />
	public class CleanInputRadio<TValue> : InputRadio<TValue>
	{
		/// <inheritdoc cref="CleanInputBase{TValue, TInput}.ContainerClass" />
		[Parameter]
		public string? ContainerClass { get; set; }

		/// <summary>
		/// The content of the label of the radio input.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		/// <inheritdoc cref="ComponentBase.OnParametersSet" />
		protected override void OnParametersSet()
		{
			base.OnParametersSet();

			var parameters = (IDictionary<string, object>?)this.AdditionalAttributes ??
							 new Dictionary<string, object>(StringComparer.Ordinal);

			parameters["class"] = $"input {parameters.GetString("class")}";

			this.AdditionalAttributes = parameters.AsReadOnly();
		}

		/// <inheritdoc cref="ComponentBase.BuildRenderTree" />
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "label");
			{
				builder.AddAttribute(1, "class", $"radio-container {this.ContainerClass}");

				base.BuildRenderTree(builder);

				builder.AddContent(2, this.ChildContent);
			}
			builder.CloseElement();
		}
	}

	/// <inheritdoc cref="InputRadioGroup{TValue}" />
	public class CleanInputRadioGroup<TValue> : InputRadioGroup<TValue>
	{
		/// <summary>
		/// Whether to display the child options in a vertical/block layout, instead of horizontal/inline.
		/// </summary>
		[Parameter]
		public bool Vertical { get; set; }

		/// <inheritdoc cref="ComponentBase.BuildRenderTree" />
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "div");
			{
				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddAttribute(
					2,
					"class",
					$"radio-group {(this.Vertical ? "radio-group-vertical" : "")} {this.AdditionalAttributes.GetString("class")}"
				);

				base.BuildRenderTree(builder);
			}
			builder.CloseElement();
		}
	}

	public class CleanInputSwitch : InputCheckbox
	{
		/// <inheritdoc cref="CleanInputBase{TValue, TInput}.ContainerClass" />
		[Parameter]
		public string? ContainerClass { get; set; }

		/// <summary>
		/// The label content to show for the checkbox.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		protected override void OnParametersSet()
		{
			var parameters = (IDictionary<string, object>?)this.AdditionalAttributes ??
							 new Dictionary<string, object>(StringComparer.Ordinal);

			parameters["role"] = "switch";
			parameters["class"] = $"switch {parameters.GetString("class")}";

			this.AdditionalAttributes = parameters.AsReadOnly();
		}

		/// <inheritdoc cref="ComponentBase.BuildRenderTree" />
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			if (this.ChildContent is null)
			{
				base.BuildRenderTree(builder);
				return;
			}

			builder.OpenElement(0, "label");
			{
				builder.AddAttribute(1, "class", $"switch-container {this.ContainerClass}");

				base.BuildRenderTree(builder);

				builder.AddContent(2, this.ChildContent);
			}
			builder.CloseElement();
		}
	}
}
