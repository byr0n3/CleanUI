using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Table
{
	public sealed partial class Sizes : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanTable Items="@(people.AsQueryable())" Size="@(TableSize.Small)">
				<CleanPropertyColumn Property="@(static (p) => p.Id)" />
				<CleanPropertyColumn Property="@(static (p) => p.FullName)" />
				<CleanPropertyColumn Property="@(static (p) => p.DateOfBirth)" Format="d" />
			</CleanTable>

			<CleanTable Items="@(people.AsQueryable())" Size="@(TableSize.Large)">
				<CleanPropertyColumn Property="@(static (p) => p.Id)" />
				<CleanPropertyColumn Property="@(static (p) => p.FullName)" />
				<CleanPropertyColumn Property="@(static (p) => p.DateOfBirth)" Format="d" />
			</CleanTable>
			""";
	}
}
