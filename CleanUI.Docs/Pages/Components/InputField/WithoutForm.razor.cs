using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.InputField
{
	public sealed partial class WithoutForm : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanInputField Property="@(() => model.Username)">
				<CleanInputText @bind-Value="@(model.Username)" />
			</CleanInputField>

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
