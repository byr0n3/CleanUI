using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Alert
{
	public sealed partial class WithIcon : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanAlert ShowIcon>
				This alert has an icon.
			</CleanAlert>
			
			<CleanAlert Type="@(AlertType.Success)" ShowIcon>
				This alert has an icon.
			</CleanAlert>
			
			<CleanAlert Type="@(AlertType.Warning)" ShowIcon>
				This alert has an icon.
			</CleanAlert>
			
			<CleanAlert Type="@(AlertType.Danger)" ShowIcon>
				This alert has an icon.
			</CleanAlert>
			""";
	}
}
