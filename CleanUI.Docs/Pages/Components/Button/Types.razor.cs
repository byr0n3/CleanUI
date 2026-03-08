using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Button
{
	public sealed partial class Types : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Button>
				Default
			</Button>

			<Button ButtonType="@(ButtonType.Primary)">
				Primary
			</Button>

			<Button ButtonType="@(ButtonType.Secondary)">
				Secondary
			</Button>

			<Button ButtonType="@(ButtonType.Danger)">
				Danger
			</Button>

			<Button ButtonType="@(ButtonType.Link)">
				Link
			</Button>
			""";
	}
}
