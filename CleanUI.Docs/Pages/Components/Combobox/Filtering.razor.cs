using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Combobox
{
	public sealed partial class Filtering : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Combobox @bind-Value="@(value)"
			          @bind-Search="@(search)"
			          @bind-Search:after="@(UpdateOptions)"
			          Options="@(options)"
			          GetOptionValue="@(static (option) => option.Value)"
			          GetOptionLabel="@(static (option) => option.Label)" />

			@code {

				private string? value;
				private string? search;
				private SelectOption[] options = Filtering.defaultOptions;

				private async Task UpdateOptionsAsync()
				{
					// Simulate loading data from a database.
					await Task.Delay(TimeSpan.FromMilliseconds(250));

					if (string.IsNullOrEmpty(search))
					{
						options = Filtering.defaultOptions;
					}
					else
					{
						options =
						[
							new SelectOption(search.ToLowerInvariant(), search),
							new SelectOption($"{search.ToLowerInvariant()}-2", $"{search} 2"),
							new SelectOption($"{search.ToLowerInvariant()}-3", $"{search} 3"),
							new SelectOption($"{search.ToLowerInvariant()}-4", $"{search} 4"),
						];
					}
				}

				private static readonly SelectOption[] defaultOptions =
				[
					new("apple", "Apple"),
					new("banana", "Banana"),
					new("cherry", "Cherry"),
					new("mango", "Mango"),
				];

				private readonly record struct SelectOption(string Value, string Label);

			}
			""";
	}
}
