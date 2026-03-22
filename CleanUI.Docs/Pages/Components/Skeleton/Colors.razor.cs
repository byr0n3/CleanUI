using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Skeleton
{
	public sealed partial class Colors : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<span class="skeleton fg-primary"></span>
			<br />
			<span class="skeleton fg-secondary"></span>
			<br />
			<span class="skeleton fg-info"></span>
			<br />
			<span class="skeleton fg-success"></span>
			<br />
			<span class="skeleton fg-warning"></span>
			<br />
			<span class="skeleton fg-danger"></span>
			<br />
			<span class="skeleton fg-disabled"></span>
			""";
	}
}
