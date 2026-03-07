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

			<Button Type="@(ButtonType.Primary)">
				Primary
			</Button>

			<Button Type="@(ButtonType.Secondary)">
				Secondary
			</Button>

			<Button Type="@(ButtonType.Danger)">
				Danger
			</Button>

			<Button Type="@(ButtonType.Link)">
				Link
			</Button>
			""";
	}
}
