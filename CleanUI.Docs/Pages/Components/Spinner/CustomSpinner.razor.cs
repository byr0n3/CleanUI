using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Spinner
{
	public sealed partial class CustomSpinner : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"<CleanSpinner SpinnerContent=\"@(Icons.Home)\" Spinning />";
	}
}
