using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Tooltip
{
	public sealed partial class JsRuntime : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanTooltip id="tooltip">
				This tooltip gets shown using the IJSRuntime.
			</CleanTooltip>

			@code {

				[Inject] public required IJSRuntime Js { get; init; }

				protected override async Task OnInitializedAsync()
				{
					await Js.ShowTooltipAsync("tooltip");
				}

			}
			""";
	}
}
