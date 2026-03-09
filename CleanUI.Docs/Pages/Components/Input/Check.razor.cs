using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class Check : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<InputCheckbox @bind-Value="@(value)">
				Stay signed in?
			</InputCheckbox>
			
			@code {
			
				private bool value;
			
			}
			""";
	}
}
