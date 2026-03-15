using System.Threading.Tasks;
using CleanUI.Internal.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;

namespace CleanUI
{
	/// <summary>
	/// A visual component that only gets displayed when its parent gets hovered/focussed.
	/// </summary>
	public class CleanTooltip : CleanComponentBase
	{
		/// <inheritdoc cref="IJSRuntime" />
		/// <remarks>This service is injected to register interactively-rendered tooltips.</remarks>
		[Inject] public required IJSRuntime Js { get; init; }

		/// <summary>
		/// The position to display the tooltip at.
		/// </summary>
		[Parameter]
		public TooltipPosition Position { get; set; }

		/// <summary>
		/// The content of the tooltip.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		/// <summary>
		/// The CSS class that represents the given <see cref="Position"/>.
		/// </summary>
		private string GetPositionClass =>
			(this.Position) switch
			{
				TooltipPosition.Right  => "tooltip-right",
				TooltipPosition.Bottom => "tooltip-bottom",
				TooltipPosition.Left   => "tooltip-left",
				_                      => "",
			};

		private ElementReference element;

		protected override Task OnAfterRenderAsync(bool firstRender) =>
			// We have to call the `window.Tooltip.register` function manually in the case of interactive rendering,
			// as the element is added to the document AFTER `DOMContentLoaded` is called, or is conditionally rendered.
			firstRender ? this.Js.RegisterTooltipAsync(this.element).AsTask() : Task.CompletedTask;

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "div");
			{
				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddAttribute(2, "class", $"tooltip {this.GetPositionClass} {this.AdditionalAttributes.GetString("class")}");
				builder.AddAttribute(3, "popover", "hint");
				builder.AddContent(4, this.ChildContent);
				builder.AddElementReferenceCapture(5, (elem) => this.element = elem);
			}
			builder.CloseElement();
		}
	}

	/// <summary>
	/// The position of a tooltip.
	/// </summary>
	public enum TooltipPosition
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
