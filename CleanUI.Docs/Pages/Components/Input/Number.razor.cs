using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public sealed partial class Number : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<InputNumber @bind-Value="@(value)" />
			<InputNumber @bind-Value="@(value)" PrefixContent="@(Icons.CoinEuro)" />

			@code {

				private int value;

			}
			""";
	}
}
