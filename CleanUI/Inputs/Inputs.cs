using System;
using System.Collections.Generic;
using System.Numerics;
using CleanUI.Internal.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

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
}
