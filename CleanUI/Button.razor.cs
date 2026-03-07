using System.Threading.Tasks;
using CleanUI.Internal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CleanUI
{
	public sealed partial class Button : CleanComponentBase
	{
		[Parameter] public ButtonType Type { get; set; }

		[Parameter] public bool Icon { get; set; }

		[Parameter] public bool Loading { get; set; }

		[Parameter] public RenderFragment? ChildContent { get; set; }

		[Parameter] public RenderFragment? PrefixContent { get; set; }

		[Parameter] public RenderFragment? SuffixContent { get; set; }

		[Parameter] public RenderFragment? LoadingContent { get; set; }

		private EventCallback<MouseEventArgs> onClickCallback;

		private string TypeClass =>
			(this.Type) switch
			{
				ButtonType.Primary   => "btn-primary",
				ButtonType.Secondary => "btn-secondary",
				ButtonType.Danger    => "btn-danger",
				ButtonType.Link      => "btn-link",
				_                    => string.Empty,
			};

		/// <inheritdoc/>
		protected override void OnParametersSet() =>
			this.OverrideOnClickCallback();

		/// <summary>
		/// Overrides the <c>onclick</c> parameter of the component, when it has a valid .NET callback.
		/// </summary>
		private void OverrideOnClickCallback()
		{
			if ((this.AdditionalParameters?.TryGetValue("onclick", out var onclick) != true) ||
				(onclick is not EventCallback<MouseEventArgs> callback))
			{
				return;
			}

			this.onClickCallback = callback;

			this.AdditionalParameters["onclick"] = EventCallback.Factory.Create<MouseEventArgs>(this, this.HandleClickAsync);
		}

		private async Task HandleClickAsync(MouseEventArgs args)
		{
			if (!this.onClickCallback.HasDelegate)
			{
				return;
			}

			this.Loading = true;

			await this.onClickCallback.InvokeAsync(args);

			this.Loading = false;
		}
	}

	public enum ButtonType
	{
		Default,
		Primary,
		Secondary,
		Danger,
		Link,
	}
}
