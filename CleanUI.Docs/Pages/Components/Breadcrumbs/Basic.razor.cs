using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Breadcrumbs
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanBreadcrumbs Label="Navigation breadcrumbs">
				<CleanBreadcrumb IconContent="@(Icons.Home)" Href="#">Home</CleanBreadcrumb>
				<CleanBreadcrumb IconContent="@(Icons.Users)" Href="#">Users</CleanBreadcrumb>
				<CleanBreadcrumb IconContent="@(Icons.User)" Href="#" Current>John Doe</CleanBreadcrumb>
			</CleanBreadcrumbs>
			""";
	}
}
