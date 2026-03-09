using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class Date : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			// Because the `InputDate` component has the same name as the built-in Razor `InputDate` component,
			// you'll have to import `InputDateType` for the `Type` parameter like this, sorry!
			@using InputDateType = Microsoft.AspNetCore.Components.Forms.InputDateType

			<InputDate @bind-Value="@(date)" PrefixContent="@(Icons.Calendar)" />
			<InputDate @bind-Value="@(dateTime)" Type="@(InputDateType.DateTimeLocal)" PrefixContent="@(Icons.CalendarClock)" />
			<InputDate @bind-Value="@(time)" Type="@(InputDateType.Time)" PrefixContent="@(Icons.Clock)" />

			@code {

				private DateOnly? date;
				private DateTime dateTime = DateTime.UtcNow;
				private TimeOnly? time;

			}
			""";
	}
}
