using System.Numerics;
using Inputs = Microsoft.AspNetCore.Components.Forms;

// @todo Add component for every input type
namespace CleanUI
{
	public sealed class InputText : CleanInputBase<string?, Inputs.InputText>;

	public sealed class InputNumber<TNumber> : CleanInputBase<TNumber, Inputs.InputNumber<TNumber>>
		where TNumber : INumber<TNumber>;
}
