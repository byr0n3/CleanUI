using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Alert
{
	public sealed partial class Types : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanAlert Type="@(AlertType.Info)">
				Hello world!
			</CleanAlert>

			<CleanAlert Type="@(AlertType.Success)">
				Hello world!
			</CleanAlert>

			<CleanAlert Type="@(AlertType.Warning)">
				Hello world!
			</CleanAlert>

			<CleanAlert Type="@(AlertType.Danger)">
				Hello world!
			</CleanAlert>
			""";
	}
}
