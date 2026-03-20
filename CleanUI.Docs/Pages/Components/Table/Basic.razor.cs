using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Table
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanTable Items="@(Items)" Pagination="@(pagination)">
				<CleanPropertyColumn Property="@(static (p) => p.Id)" Sortable="@(true)" />
				<CleanPropertyColumn Property="@(static (p) => p.FullName)" Sortable="@(true)">
					<ColumnOptions>
						<CleanInputText @bind-Value="@(search)" type="search" placeholder="Search for people…" />
					</ColumnOptions>
				</CleanPropertyColumn>
				<CleanPropertyColumn Property="@(static (p) => p.DateOfBirth)" Format="d" Sortable="@(true)" />
				<CleanPropertyColumn Property="@(static (p) => p.Email)">
					<a href="@($"mailto:{context}")">@(context)</a>
				</CleanPropertyColumn>
				<CleanPropertyColumn Property="@(static (p) => p.Created)" Format="g" Sortable="@(true)" />
			</CleanTable>
			
			<CleanPagination Label="Pagination" Pagination="@(pagination)" />
			
			@code {
			
				private IQueryable<Person> Items
				{
					get
					{
						var query = people.AsQueryable();
			
						if (!string.IsNullOrEmpty(search))
						{
							query = query.Where((p) => p.FullName.Contains(search, StringComparison.OrdinalIgnoreCase));
						}
			
						return query;
					}
				}
			
				private readonly Person[] people = […];
			
				private readonly PaginationState pagination = new() { ItemsPerPage = 10 };
			
				private string? search;
			
				private readonly record struct Person
				{
					[Display(Name = "Id")] public readonly int Id;
					public readonly string GivenName;
					public readonly string FamilyName;
					[Display(Name = "Birthday")] public readonly DateOnly DateOfBirth;
					[Display(Name = "E-mail")] public readonly string Email;
					[Display(Name = "Created at")] public readonly DateTimeOffset Created;
			
					[Display(Name = "Name")]
					public string FullName =>
						$"{GivenName} {FamilyName}";
				}
			
			}
			""";
	}
}
