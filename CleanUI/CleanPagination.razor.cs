using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace CleanUI
{
	/// <summary>
	/// Component that indicates a series of related content that exists across multiple pages and provides functionality to switch to said pages.
	/// </summary>
	public partial class CleanPagination : CleanComponentBase, IDisposable
	{
		/// <inheritdoc cref="NavigationManager" />
		[Inject]
		public required NavigationManager Navigation { get; init; }

		/// <summary>
		/// The <c>aria-label</c> for the navigation element.
		/// </summary>
		/// <remarks>This parameter is required to make screenreaders communicate what the function of this element is.</remarks>
		[Parameter]
		[EditorRequired]
		public required string Label { get; set; }

		/// <summary>
		/// The currently active page.
		/// </summary>
		[Parameter]
		public int Page { get; set; }

		/// <summary>
		/// Callback that gets invoked when the user navigates to another page.
		/// </summary>
		[Parameter]
		public EventCallback<int> PageChanged { get; set; }

		/// <summary>
		/// The amount of items that gets displayed per page.
		/// </summary>
		[Parameter]
		public int PerPage { get; set; }

		/// <summary>
		/// The total amount of items (unpaginated).
		/// </summary>
		[Parameter]
		public int TotalCount { get; set; }

		/// <summary>
		/// The name of the query parameter for the <see cref="Page"/> parameter.
		/// </summary>
		[Parameter]
		public string PageQueryName { get; set; } = nameof(CleanPagination.Page);

		/// <inheritdoc cref="PaginationState" />
		[Parameter]
		public PaginationState? Pagination { get; set; }

		/// <summary>
		/// The icon/content to display for the `previous page` button.
		/// </summary>
		[Parameter]
		public RenderFragment PreviousPageContent { get; set; } = Icons.ChevronLeft;

		/// <summary>
		/// The icon/content to display for the `next page` button.
		/// </summary>
		[Parameter]
		public RenderFragment NextPageContent { get; set; } = Icons.ChevronRight;

		/// <summary>
		/// The total amount of available pages.
		/// </summary>
		private int PageCount =>
			this.Pagination is not null
				? this.Pagination.LastPageIndex.GetValueOrDefault() + 1
				: (int)float.Ceiling(this.TotalCount / (float)this.PerPage);

		/// <inheritdoc />
		protected override void OnParametersSet()
		{
			this.Page = this.ClampPage(this.Page);

			if (this.Pagination is null)
			{
				return;
			}

			this.Page = this.Pagination.CurrentPageIndex + 1;
			this.PerPage = this.Pagination.ItemsPerPage;

			this.Pagination.TotalItemCountChanged -= this.UpdateTotalCount;
			this.Pagination.TotalItemCountChanged += this.UpdateTotalCount;
		}

		/// <summary>
		/// Updates the current <see cref="TotalCount"/> when the <see cref="PaginationState.TotalItemCountChanged"/> is fired.
		/// </summary>
		/// <param name="__">Unused.</param>
		/// <param name="count">The new total count.</param>
		private void UpdateTotalCount(object? __, int? count)
		{
			this.TotalCount = count ?? 0;

			_ = this.InvokeAsync(this.StateHasChanged);
		}

		/// <summary>
		/// Gets the page buttons to currently show.
		/// </summary>
		/// <returns>The page numbers to show.</returns>
		private IEnumerable<int> GetPages()
		{
			const int centerOffset = 1;

			var pageCount = this.PageCount;

			// Calculate the first- and last page button, while trying to keep the current page as the middle-most button.
			var lower = int.Max(this.Page - centerOffset, 1);
			var upper = int.Min(this.Page + centerOffset, this.PageCount);

			// Show the `first page` button when there's more than 3 pages.
			if (this.Page > (1 + centerOffset))
			{
				yield return 1;

				// Show a `divider` button when there's more than 4 pages.
				if (this.Page > (centerOffset * 2))
				{
					yield return -1;
				}
			}

			// Show all page buttons using the calculated page values from before.
			for (var i = lower; i <= upper; i++)
			{
				yield return i;
			}

			// Show the `last page` button when we're more than 2 pages away from the end.
			if (this.Page < (pageCount - centerOffset))
			{
				// Show a `divider` button when we're more than 3 pages away from the end.
				if (this.Page < (pageCount - centerOffset - 1))
				{
					yield return -1;
				}

				yield return pageCount;
			}
		}

		/// <summary>
		/// Navigates to the given <paramref name="page"/>.
		/// </summary>
		/// <param name="page">The page to navigate to.</param>
		/// <returns>A <see cref="Task"/> that completes when the current page has been updated.</returns>
		private Task GoToPageAsync(int page)
		{
			if ((page <= 0) || (page > this.PageCount))
			{
				return Task.CompletedTask;
			}

			if (this.Pagination is null)
			{
				return this.PageChanged.InvokeAsync(page);
			}

			this.Page = page;

			return this.Pagination.SetCurrentPageIndexAsync(page - 1);
		}

		/// <summary>
		/// Gets a URI that is based off the current URI (and its parameters), with the page query parameter added to it.
		/// </summary>
		/// <param name="page">The page to create the URI for.</param>
		/// <returns>A URI to the current page with the page query parameter.</returns>
		private string GetPageHref(int page)
		{
			page = this.ClampPage(page);

			return this.Navigation.GetUriWithQueryParameter(this.PageQueryName, page);
		}

		/// <summary>
		/// Clamps the given <paramref name="page"/> between <c>1</c> and the total <see cref="PageCount"/>.
		/// </summary>
		/// <param name="page">The page number to clamp.</param>
		/// <returns>The clamped page number.</returns>
		private int ClampPage(int page) =>
			int.Clamp(page, 1, this.PageCount);

		/// <inheritdoc />
		public void Dispose()
		{
			if (this.Pagination is not null)
			{
				this.Pagination.TotalItemCountChanged -= this.UpdateTotalCount;
			}

			GC.SuppressFinalize(this);
		}
	}
}
