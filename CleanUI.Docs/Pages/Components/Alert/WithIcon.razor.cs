using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Alert
{
	public sealed partial class WithIcon : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Alert ShowIcon>
				This alert has an icon.
			</Alert>
			
			<Alert Type="@(AlertType.Success)" ShowIcon>
				This alert has an icon.
			</Alert>
			
			<Alert Type="@(AlertType.Warning)" ShowIcon>
				This alert has an icon.
			</Alert>
			
			<Alert Type="@(AlertType.Danger)" ShowIcon>
				This alert has an icon.
			</Alert>
			""";
	}
}
