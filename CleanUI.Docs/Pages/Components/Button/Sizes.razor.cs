using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Button
{
	public sealed partial class Sizes : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton Size="@(ButtonSize.ExtraSmall)">
				Extra small
			</CleanButton>
			
			<CleanButton Size="@(ButtonSize.Small)">
				Small
			</CleanButton>
			
			<CleanButton>
				Default (medium)
			</CleanButton>
			
			<CleanButton Size="@(ButtonSize.Large)">
				Large
			</CleanButton>
			
			<CleanButton Size="@(ButtonSize.ExtraLarge)">
				Extra large
			</CleanButton>
			""";
	}
}
