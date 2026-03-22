using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Breadcrumbs
{
	public sealed partial class CustomDivider : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanBreadcrumbs Label="Navigation breadcrumbs" Divider="/">
				<CleanBreadcrumb IconContent="@(Icons.Home)" Href="#">Home</CleanBreadcrumb>
				<CleanBreadcrumb IconContent="@(Icons.Users)" Href="#" Current>Users</CleanBreadcrumb>
			</CleanBreadcrumbs>
			""";
	}
}
