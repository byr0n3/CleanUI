using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Progress
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<progress class="progress d-block"></progress>
			<progress class="progress d-block" max="100" value="70"></progress>
			""";
	}
}
