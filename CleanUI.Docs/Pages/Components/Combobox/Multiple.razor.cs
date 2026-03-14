using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Combobox
{
	public sealed partial class Multiple : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanCombobox @bind-Value="@(value)"
			          		Options="@(options)"
			          		GetOptionValue="@(static (option) => option.Value)"
			          		GetOptionLabel="@(static (option) => option.Label)" />

			@code {

				private string[] value = [Multiple.options[0].Value, Multiple.options[^1].Value];

				private static readonly SelectOption[] options =
				[
					new("apple", "Apple"),
					new("banana", "Banana"),
					new("cherry", "Cherry"),
					new("mango", "Mango"),
					new("strawberry", "Strawberry"),
					new("lemon", "Lemon"),
					new("watermelon", "Watermelon"),
				];

				private readonly record struct SelectOption(string Value, string Label);

			}
			""";
	}
}
