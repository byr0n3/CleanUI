using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Pagination
{
	public sealed partial class Interactive : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Pagination @bind-Page="@(page)"
			            @bind-Page:after="@(UpdatePageQueryParameter)"
			            Label="Pagination with interactive server rendering"
			            PerPage="@(10)"
			            TotalCount="@(50)" />
			
			@code {
			
				[Inject] public required NavigationManager Navigation { get; init; }
			
				private int page;
			
				private void UpdatePageQueryParameter()
				{
					var uri = Navigation.GetUriWithQueryParameter("Page", page);
			
					Navigation.NavigateTo(uri);
				}
			
			}
			""";
	}
}
