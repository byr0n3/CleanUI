using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Table
{
	public sealed partial class Striped : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanTable Items="@(people.AsQueryable())" Striped>
				<CleanPropertyColumn Property="@(static (p) => p.Id)" Sortable="@(true)" />
				<CleanPropertyColumn Property="@(static (p) => p.FullName)" Sortable="@(true)" />
				<CleanPropertyColumn Property="@(static (p) => p.DateOfBirth)" Format="d" Sortable="@(true)" />
			</CleanTable>
			""";
	}
}
