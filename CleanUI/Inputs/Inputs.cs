using System;
using System.Collections.Generic;
using System.Numerics;
using CleanUI.Internal.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Inputs = Microsoft.AspNetCore.Components.Forms;

// @todo Add component for every input type
namespace CleanUI
{
	/// <inheritdoc cref="Inputs.InputText"/>
	public sealed class InputText : CleanInputBase<string?, Inputs.InputText>;

	/// <inheritdoc cref="Inputs.InputNumber{TValue}"/>
	public sealed class InputNumber<TValue> : CleanInputBase<TValue, Inputs.InputNumber<TValue>>
		where TValue : INumber<TValue>;

	/// <inheritdoc cref="Inputs.InputDate{TValue}"/>
	public sealed class InputDate<TValue> : CleanInputBase<TValue, Inputs.InputDate<TValue>>
	{
		/// <inheritdoc cref="Inputs.InputDate{TValue}.Type"/>
		[Parameter]
		public InputDateType Type { get; set; } = InputDateType.Date;

		protected override Dictionary<string, object> ComponentParameters =>
			new(StringComparer.Ordinal)
			{
				[nameof(Inputs.InputDate<>.Type)] = this.Type,
			};
	}

	/// <inheritdoc cref="Inputs.InputTextArea"/>
	public sealed class InputTextArea : CleanInputBase<string?, Inputs.InputTextArea>;

	/// <inheritdoc cref="Inputs.InputFile"/>
	public sealed class InputFile : Inputs.InputFile
	{
		protected override void OnParametersSet()
		{
			var parameters = this.AdditionalAttributes ?? new Dictionary<string, object>(StringComparer.Ordinal);

			parameters["class"] = $"input {parameters.GetString("class")}";

			this.AdditionalAttributes = parameters;
		}
	}
}
