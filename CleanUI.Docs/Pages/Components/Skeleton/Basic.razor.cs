using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Skeleton
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<span class="skeleton skeleton-sm"></span>
			<br/>
			<span class="skeleton"></span>
			<br/>
			<span class="skeleton skeleton-lg"></span>
			""";
	}
}
