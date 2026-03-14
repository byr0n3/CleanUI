using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class TextArea : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanInputTextArea @bind-Value="@(text)" placeholder="Hello world!" />
			<CleanInputTextArea @bind-Value="@(description)" rows="4" />

			@code {

				private string? text;

				private string description = "…";

			}
			""";
	}
}
