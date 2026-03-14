using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class Text : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanInputText @bind-Value="@(text)" placeholder="Hello world!" />
			<CleanInputText @bind-Value="@(username)" PrefixContent="@(Icons.User)" />
			
			@code {
			
				private string? text;
				private string? username = "admin";
			
			}
			""";
	}
}
