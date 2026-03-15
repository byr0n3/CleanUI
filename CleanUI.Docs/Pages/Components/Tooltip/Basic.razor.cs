using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Tooltip
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton>
				Default
				<CleanTooltip>
					This tooltip is aligned to the top.
				</CleanTooltip>
			</CleanButton>

			<CleanButton>
				Right
				<CleanTooltip Position="@(TooltipPosition.Right)">
					This tooltip is aligned to the right.
				</CleanTooltip>
			</CleanButton>

			<CleanButton>
				Bottom
				<CleanTooltip Position="@(TooltipPosition.Bottom)">
					This tooltip is aligned to the bottom.
				</CleanTooltip>
			</CleanButton>

			<CleanButton>
				Left
				<CleanTooltip Position="@(TooltipPosition.Left)">
					This tooltip is aligned to the left.
				</CleanTooltip>
			</CleanButton>
			""";
	}
}
