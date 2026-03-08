using System;
using System.Collections.Frozen;
using System.Linq;
using System.Reflection;
using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Icon
{
	public sealed partial class All : ComponentBase, IComponentExample
	{
		private const int perPage = 40;

		private static readonly FrozenDictionary<string, RenderFragment> allIcons =
			typeof(Icons)
				.GetFields(BindingFlags.Public | BindingFlags.Static)
				.ToFrozenDictionary(static (property) => property.Name,
									static (property) => (RenderFragment)property.GetValue(null)!);

		public static string? Code =>
			null;

		[Parameter]
		[SupplyParameterFromQuery(Name = nameof(All.Page))]
		public int Page { get; set; } = 1;

		[Parameter]
		[SupplyParameterFromQuery(Name = nameof(All.Search))]
		public string? Search { get; set; }

		private FrozenDictionary<string, RenderFragment> filteredIcons = All.allIcons;

		protected override void OnInitialized()
		{
			if (string.IsNullOrEmpty(this.Search))
			{
				this.filteredIcons = All.allIcons;
			}
			else
			{
				this.filteredIcons = All.allIcons
										.Where((pair) => pair.Key.Contains(this.Search, StringComparison.OrdinalIgnoreCase))
										.ToFrozenDictionary();
			}
		}
	}
}
