using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Table
{
	public sealed partial class Hover : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanTable Items="@(people.AsQueryable())" Hoverable>
				<CleanPropertyColumn Property="@(static (p) => p.Id)" Sortable="@(true)" />
				<CleanPropertyColumn Property="@(static (p) => p.FullName)" Sortable="@(true)" />
				<CleanPropertyColumn Property="@(static (p) => p.DateOfBirth)" Format="d" Sortable="@(true)" />
			</CleanTable>

			<CleanTable Items="@(people.AsQueryable())" Striped Hoverable>
				<CleanPropertyColumn Property="@(static (p) => p.Id)" Sortable="@(true)" />
				<CleanPropertyColumn Property="@(static (p) => p.FullName)" Sortable="@(true)" />
				<CleanPropertyColumn Property="@(static (p) => p.DateOfBirth)" Format="d" Sortable="@(true)" />
			</CleanTable>
			""";
	}
}
