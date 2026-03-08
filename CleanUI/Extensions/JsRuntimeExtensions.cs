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
			public ValueTask OpenModalAsync(string id, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Modal.open", token, id);

			public ValueTask CloseModalAsync(string id, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Modal.close", token, id);
		}
	}
}
