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
	public class CleanTooltip : CleanPopover
	{
		/// <inheritdoc cref="IJSRuntime" />
		/// <remarks>This service is injected to register interactively-rendered tooltips.</remarks>
		[Inject] public required IJSRuntime Js { get; init; }

		private ElementReference element;

		/// <inheritdoc />
		protected override Task OnAfterRenderAsync(bool firstRender) =>
			// We have to call the `window.Tooltip.register` function manually in the case of interactive rendering,
			// as the element is added to the document AFTER `DOMContentLoaded` is called, or is conditionally rendered.
			firstRender ? this.Js.RegisterTooltipAsync(this.element).AsTask() : Task.CompletedTask;

		/// <inheritdoc />
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "div");
			{
				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddAttribute(2, "class", $"popover {this.GetPositionClass} {this.AdditionalAttributes.GetString("class")}");
				builder.AddAttribute(3, "popover", "hint");
				builder.AddContent(4, this.ChildContent);
				builder.AddElementReferenceCapture(5, (elem) => this.element = elem);
			}
			builder.CloseElement();
		}
	}
}
