using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Popconfirm
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton popovertarget="popconfirm" popovertargetaction="toggle">
				Default
			</CleanButton>

			<CleanButton popovertarget="popconfirm-right" popovertargetaction="toggle">
				Right
			</CleanButton>

			<CleanButton popovertarget="popconfirm-bottom" popovertargetaction="toggle">
				Bottom
			</CleanButton>

			<CleanButton popovertarget="popconfirm-left" popovertargetaction="toggle">
				Left
			</CleanButton>

			<CleanPopconfirm id="popconfirm">
				Are you sure you want to run this action?
			</CleanPopconfirm>

			<CleanPopconfirm Id="popconfirm-right" Position="@(PopoverPosition.Right)">
				Are you sure you want to run this action?
			</CleanPopconfirm>

			<CleanPopconfirm Id="popconfirm-bottom" Position="@(PopoverPosition.Bottom)">
				Are you sure you want to run this action?
			</CleanPopconfirm>

			<CleanPopconfirm Id="popconfirm-left" Position="@(PopoverPosition.Left)">
				Are you sure you want to run this action?
			</CleanPopconfirm>
			""";
	}
}
