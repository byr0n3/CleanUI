using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Alert
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Alert>
				Hello world!
			</Alert>

			<Alert Type="@(AlertType.Info)">
				Hello world!
			</Alert>

			<Alert Type="@(AlertType.Success)">
				Hello world!
			</Alert>

			<Alert Type="@(AlertType.Warning)">
				Hello world!
			</Alert>

			<Alert Type="@(AlertType.Danger)">
				Hello world!
			</Alert>
			""";
	}
}
