using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class Range : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanInputNumber @bind-Value="@(value)" type="range" min="0" max="100" />
			<CleanInputNumber @bind-Value="@(value2)" PrefixContent="@(Icons.Minus)" SuffixContent="@(Icons.Plus)" type="range" min="0" max="100" />

			@code {

				private int value = 50;
				private int value2;

			}
			""";
	}
}
