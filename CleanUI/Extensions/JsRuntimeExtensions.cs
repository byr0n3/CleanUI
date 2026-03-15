using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CleanUI
{
	[PublicAPI]
	public static class JsRuntimeExtensions
	{
		extension(IJSRuntime js)
		{
			/// <summary>
			/// Opens a modal, located using the given <paramref name="id"/>.
			/// </summary>
			/// <param name="id">The ID of the modal to open.</param>
			/// <param name="token">Cancellation token to cancel the async-operation.</param>
			/// <returns>A <see cref="ValueTask"/> that completes when the <c>window.Modal.open</c> has been called.</returns>
			public ValueTask OpenModalAsync(string id, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Modal.open", token, id);

			/// <summary>
			/// Closes a modal, located using the given <paramref name="id"/>.
			/// </summary>
			/// <param name="id">The ID of the modal to close.</param>
			/// <param name="token">Cancellation token to cancel the async-operation.</param>
			/// <returns>A <see cref="ValueTask"/> that completes when the <c>window.Modal.close</c> has been called.</returns>
			public ValueTask CloseModalAsync(string id, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Modal.close", token, id);

			/// <summary>
			/// Register a tooltip so it gets displayed when its parent gets hovered.
			/// </summary>
			/// <param name="element">The tooltip to register.</param>
			/// <param name="token">Cancellation token to cancel the async-operation.</param>
			/// <returns>A <see cref="ValueTask"/> that completes when the <c>window.Tooltip.register</c> has been called.</returns>
			public ValueTask RegisterTooltipAsync(ElementReference element, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Tooltip.register", token, element);

			/// <summary>
			/// Shows a tooltip, located using the given <paramref name="id"/>.
			/// </summary>
			/// <param name="id">The ID of the tooltip to show.</param>
			/// <param name="token">Cancellation token to cancel the async-operation.</param>
			/// <returns>A <see cref="ValueTask"/> that completes when the <c>window.Tooltip.show</c> has been called.</returns>
			public ValueTask ShowTooltipAsync(string id, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Tooltip.show", token, id);

			/// <summary>
			/// Hides a tooltip, located using the given <paramref name="id"/>.
			/// </summary>
			/// <param name="id">The ID of the tooltip to hide.</param>
			/// <param name="token">Cancellation token to cancel the async-operation.</param>
			/// <returns>A <see cref="ValueTask"/> that completes when the <c>window.Tooltip.hide</c> has been called.</returns>
			public ValueTask HideTooltipAsync(string id, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Tooltip.hide", token, id);
		}
	}
}
