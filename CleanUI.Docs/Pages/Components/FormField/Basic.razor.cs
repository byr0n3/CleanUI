using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.FormField
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<EditForm Model="@(Model)">
				<DataAnnotationsValidator />

				<CleanFormField Property="@(() => Model.Username)">
					<CleanInputText @bind-Value="@(Model.Username)" />
				</CleanFormField>

				<CleanFormField Property="@(() => Model.Password)">
					<ChildContent>
						<CleanInputText @bind-Value="@(Model.Password)" type="password" />
					</ChildContent>

					<HelpContent>
						Please try to make your password have at least 8 characters!
					</HelpContent>
				</CleanFormField>

				<CleanButton ButtonType="@(ButtonType.Primary)" type="submit">
					Sign in
				</CleanButton>
			</EditForm>

			@code {

				private BasicModel Model { get; set; } = new();

				private sealed class BasicModel
				{
					[Required]
					[Display(Name = "Your username")]
					public string? Username { get; set; }

					[Required]
					[Display(Name = "Your super secure password")]
					public string? Password { get; set; }
				}

			}
			""";
	}
}
