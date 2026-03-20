using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Table
{
	public sealed partial class Bordered : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanTable Items="@(people.AsQueryable())" Bordered>
				<CleanPropertyColumn Property="@(static (p) => p.Id)" />
				<CleanPropertyColumn Property="@(static (p) => p.FullName)" />
				<CleanPropertyColumn Property="@(static (p) => p.DateOfBirth)" Format="d" />
			</CleanTable>
			""";
	}
}
