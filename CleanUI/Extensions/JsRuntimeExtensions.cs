using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.JSInterop;

namespace CleanUI
{
	[PublicAPI]
	public static class JsRuntimeExtensions
	{
		extension(IJSRuntime js)
		{
			/// <summary>
			/// Opens a modal, localed using the given <paramref name="id"/>.
			/// </summary>
			/// <param name="id">The ID of the modal to open.</param>
			/// <param name="token">Cancellation token to cancel the async-operation..</param>
			/// <returns>A <see cref="ValueTask"/> that completes when the <c>window.Modal.open</c> has been called.</returns>
			public ValueTask OpenModalAsync(string id, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Modal.open", token, id);

			/// <summary>
			/// Closes a modal, localed using the given <paramref name="id"/>.
			/// </summary>
			/// <param name="id">The ID of the modal to close.</param>
			/// <param name="token">Cancellation token to cancel the async-operation..</param>
			/// <returns>A <see cref="ValueTask"/> that completes when the <c>window.Modal.close</c> has been called.</returns>
			public ValueTask CloseModalAsync(string id, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Modal.close", token, id);
		}
	}
}
