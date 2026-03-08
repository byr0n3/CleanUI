using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Button
{
	public sealed partial class IconOnly : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Button IconOnly>
				@(Icons.User)
			</Button>
			
			<Button ButtonType="@(ButtonType.Primary)" IconOnly>
				@(Icons.User)
			</Button>
			
			<Button ButtonType="@(ButtonType.Secondary)" IconOnly>
				@(Icons.User)
			</Button>
			
			<Button ButtonType="@(ButtonType.Danger)" IconOnly>
				@(Icons.User)
			</Button>
			
			<Button ButtonType="@(ButtonType.Link)" IconOnly>
				@(Icons.User)
			</Button>
			""";
	}
}
