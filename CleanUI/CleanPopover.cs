using CleanUI.Internal.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace CleanUI
{
	/// <summary>
	/// A floating element displayed when clicking the trigger's element.
	/// </summary>
	public class CleanPopover : CleanComponentBase
	{
		/// <summary>
		/// The position to display the popover at.
		/// </summary>
		[Parameter]
		public CleanPopoverPosition Position { get; set; }

		/// <summary>
		/// The content of the popover.
		/// </summary>
		[Parameter]
		[EditorRequired]
		public required RenderFragment ChildContent { get; set; }

		/// <summary>
		/// The CSS class that represents the given <see cref="Position"/>.
		/// </summary>
		protected string GetPositionClass =>
			(this.Position) switch
			{
				CleanPopoverPosition.Right  => "popover-right",
				CleanPopoverPosition.Bottom => "popover-bottom",
				CleanPopoverPosition.Left   => "popover-left",
				_                           => "",
			};

		/// <inheritdoc />
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "div");
			{
				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddAttribute(3, "popover");
				builder.AddAttribute(4, "class", $"popover {this.GetPositionClass} {this.AdditionalAttributes.GetString("class")}");
				builder.AddContent(5, this.ChildContent);
			}
			builder.CloseElement();
		}
	}

	/// <summary>
	/// The position of a tooltip.
	/// </summary>
	public enum CleanPopoverPosition
	{
		/// <summary>
		/// Displays a tooltip at the top of the parent.
		/// </summary>
		Top,

		/// <summary>
		/// Displays a tooltip to the right of the parent.
		/// </summary>
		Right,

		/// <summary>
		/// Displays a tooltip at the bottom of the parent.
		/// </summary>
		Bottom,

		/// <summary>
		/// Displays a tooltip to the left of the parent.
		/// </summary>
		Left,
	}
}
