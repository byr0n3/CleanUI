using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class Radio : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanInputRadioGroup @bind-Value="@(@checked)">
				<CleanInputRadio Value="@(true)">
					Yes
				</CleanInputRadio>
				<CleanInputRadio Value="@(false)">
					No
				</CleanInputRadio>
			</CleanInputRadioGroup>

			<CleanInputRadioGroup @bind-Value="@(value)" Vertical>
				<CleanInputRadio Value="@("Hello")">
					Hello
				</CleanInputRadio>
				<CleanInputRadio Value="@("there")">
					there
				</CleanInputRadio>
				<CleanInputRadio Value="@("general")">
					general
				</CleanInputRadio>
				<CleanInputRadio Value="@("Kenobi")">
					Kenobi
				</CleanInputRadio>
			</CleanInputRadioGroup>

			@code {

				private bool @checked;
				private string? value;

			}
			""";
	}
}
