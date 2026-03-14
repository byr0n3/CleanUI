using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.FormField
{
	public sealed partial class CustomErrorMessage : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanFormField Property="@(() => model.Username)">
				<ChildContent>
					<CleanInputText @bind-Value="@(model.Username)" />
				</ChildContent>
				
				<ErrorContent>
					Please enter your username.
				</ErrorContent>
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
