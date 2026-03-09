using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class TextArea : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<InputTextArea @bind-Value="@(text)" placeholder="Hello world!" />
			<InputTextArea @bind-Value="@(description)" rows="4" />

			@code {

				private string? text;

				private string description = "…";

			}
			""";
	}
}
