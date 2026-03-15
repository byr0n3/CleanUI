using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class Check : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanInputCheckbox @bind-Value="@(value)" />
			<CleanInputCheckbox @bind-Value="@(value)">
				Stay signed in?
			</CleanInputCheckbox>
			
			@code {
			
				private bool value;
			
			}
			""";
	}
}
