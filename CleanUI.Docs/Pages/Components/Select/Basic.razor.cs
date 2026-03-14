using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Select
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanSelect @bind-Value="@(value)"
			        	 Options="@(Basic.options)"
			        	 GetOptionValue="@(static (option) => option.Value)"
			        	 GetOptionLabel="@(static (option) => option.Label)"
			        	 GetOptionIcon="@(Basic.GetOptionIcon)"
			        	 AddNullOption
			        	 NullOptionLabel="Pick a fruit!">
			</CleanSelect>

			@code {

				private string? value;

				private static readonly SelectOption[] options =
				[
					new("apple", "Apple"),
					new("banana", "Banana"),
					new("cherry", "Cherry"),
					new("mango", "Mango"),
				];

				private static RenderFragment? GetOptionIcon(SelectOption option) =>
					(option.Value) switch
					{
						"apple"  => Icons.Apple,
						"cherry" => Icons.Cherry,
						_        => null,
					};

				private readonly record struct SelectOption(string Value, string Label);

			}
			""";
	}
}
