using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class Date : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanInputDate @bind-Value="@(date)" PrefixContent="@(Icons.Calendar)" />
			<CleanInputDate @bind-Value="@(dateTime)" Type="@(InputDateType.DateTimeLocal)" PrefixContent="@(Icons.CalendarClock)" SuffixContent="@(Icons.CalendarCheck)" />
			<CleanInputDate @bind-Value="@(time)" Type="@(InputDateType.Time)" PrefixContent="@(Icons.Clock)" SuffixContent="@(Icons.Alarm)" />

			@code {

				private DateOnly? date;
				private DateTime dateTime = DateTime.UtcNow;
				private TimeOnly? time;

			}
			""";
	}
}
