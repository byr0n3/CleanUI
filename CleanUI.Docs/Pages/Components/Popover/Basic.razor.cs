using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Popover
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton popovertarget="popover" popovertargetaction="toggle">
				Default
			</CleanButton>

			<CleanButton popovertarget="popover-right" popovertargetaction="toggle">
				Right
			</CleanButton>

			<CleanButton popovertarget="popover-bottom" popovertargetaction="toggle">
				Bottom
			</CleanButton>

			<CleanButton popovertarget="popover-left" popovertargetaction="toggle">
				Left
			</CleanButton>

			<CleanPopover id="popover">
				This popover is aligned to the top.
			</CleanPopover>

			<CleanPopover id="popover-right" Position="@(PopoverPosition.Right)">
				This popover is aligned to the right.
			</CleanPopover>

			<CleanPopover id="popover-bottom" Position="@(PopoverPosition.Bottom)">
				This popover is aligned to the bottom.
			</CleanPopover>

			<CleanPopover id="popover-left" Position="@(PopoverPosition.Left)">
				This popover is aligned to the left.
			</CleanPopover>
			""";
	}
}
