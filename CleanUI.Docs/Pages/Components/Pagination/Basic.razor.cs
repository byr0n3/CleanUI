using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Pagination
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanPagination Label="A basic pagination example" Page="@(Page)" PerPage="@(5)" TotalCount="@(50)" />

			@code {

				[Parameter]
				[SupplyParameterFromQuery(Name = nameof(Basic.Page))]
				public int Page { get; set; } = 1;

				// The `<Pagination />` component will automatically clamp the given page.
				// However, it's good practice to clamp the page in your own component as well.
				// If no `Page` query parameter is given, Blazor will automatically set the parameter's value to `0`.
				protected override void OnInitialized() =>
					Page = int.Clamp(Page, 1, 10);

			}
			""";
	}
}
