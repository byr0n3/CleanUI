using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.InputField
{
	public sealed partial class CustomLabel : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanInputField Property="@(() => model.Username)">
				<LabelContent>
					<i>Your</i> <b>username</b>:
				</LabelContent>
			
				<ChildContent>
					<CleanInputText @bind-Value="@(model.Username)" />
				</ChildContent>
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
