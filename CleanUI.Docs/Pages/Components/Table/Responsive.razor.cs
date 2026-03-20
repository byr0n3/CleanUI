using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Table
{
	public sealed partial class Responsive : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			// Possible values: None (default, never responsive), Always, ExtraSmall, Small, Medium, Large, ExtraLarge
			<CleanTable Items="@(people.AsQueryable())" Responsiveness="@(TableResponsiveness.Always)">
				…
			</CleanTable>
			""";
	}
}
