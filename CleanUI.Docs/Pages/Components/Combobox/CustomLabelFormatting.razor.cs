using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Combobox
{
	public sealed partial class CustomLabelFormatting : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanCombobox @bind-Value="@(value)"
			          		Options="@(options)"
			          		GetOptionValue="@(static (option) => option.Value)"
			          		GetOptionLabel="@(static (option) => option.Label)"
			          		GetOptionIcon="@(static (option) => option.Icon)"
			          		FormatLabel="@(FormatLabel)" />

			@code {

				private string[] value = [];

				private static readonly SelectOption[] options =
				[
					new("apple", "Apple", Icons.Apple),
					new("banana", "Banana"),
					new("cherry", "Cherry", Icons.Cherry),
					new("mango", "Mango"),
					new("strawberry", "Strawberry"),
					new("lemon", "Lemon", Icons.Lemon2),
					new("watermelon", "Watermelon", Icons.Lemon),
				];

				private static RenderFragment FormatLabel(SelectOption[] selected) =>
					RenderFragment.FromString($"{selected.Length} item(s)");

				private readonly record struct SelectOption(string Value, string Label, RenderFragment? Icon = null);

			}

			""";
	}
}
