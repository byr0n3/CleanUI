using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Button
{
	public sealed partial class Types : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton>
				Default
			</CleanButton>

			<CleanButton ButtonType="@(ButtonType.Primary)">
				Primary
			</CleanButton>

			<CleanButton ButtonType="@(ButtonType.Secondary)">
				Secondary
			</CleanButton>

			<CleanButton ButtonType="@(ButtonType.Danger)">
				Danger
			</CleanButton>

			<CleanButton ButtonType="@(ButtonType.Link)">
				Link
			</CleanButton>
			""";
	}
}
