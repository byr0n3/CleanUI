using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.FormField
{
	public sealed partial class WithoutForm : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanFormField Property="@(() => model.Username)">
				<CleanInputText @bind-Value="@(model.Username)" />
			</CleanFormField>

			@code {

				private readonly BasicModel model = new();

				private sealed class BasicModel
				{
					[Required] public string? Username { get; set; }
				}

			}
			""";
	}
}
