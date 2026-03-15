using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class Switch : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanInputSwitch @bind-Value="@(value)" />
			<CleanInputSwitch @bind-Value="@(value)">
				Enabled
			</CleanInputSwitch>
			
			@code {
			
				private bool value;
			
			}
			""";
	}
}
