using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Button
{
	public sealed partial class Icon : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Button Icon>
				@(Icons.User)
			</Button>
			
			<Button Type="@(ButtonType.Primary)" Icon>
				@(Icons.User)
			</Button>
			
			<Button Type="@(ButtonType.Secondary)" Icon>
				@(Icons.User)
			</Button>
			
			<Button Type="@(ButtonType.Danger)" Icon>
				@(Icons.User)
			</Button>
			
			<Button Type="@(ButtonType.Link)" Icon>
				@(Icons.User)
			</Button>
			""";
	}
}
