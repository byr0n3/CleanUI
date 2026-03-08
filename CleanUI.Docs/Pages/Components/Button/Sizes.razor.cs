using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Button
{
	public sealed partial class Sizes : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Button Size="@(ButtonSize.ExtraSmall)">
				Extra small
			</Button>
			
			<Button Size="@(ButtonSize.Small)">
				Small
			</Button>
			
			<Button>
				Default (medium)
			</Button>
			
			<Button Size="@(ButtonSize.Large)">
				Large
			</Button>
			
			<Button Size="@(ButtonSize.ExtraLarge)">
				Extra large
			</Button>
			""";
	}
}
