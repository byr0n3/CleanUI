using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Modal
{
	public sealed partial class JsRuntime : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			@code {

				[Inject] public required IJSRuntime Js { get; init; }

				protected override async Task OnInitializedAsync()
				{
					await Js.OpenModalAsync("modal");
				}

			}
			""";
	}
}
