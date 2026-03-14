using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CleanUI
{
	/// <summary>
	/// A clickable element that executes a given functionality when clicked.
	/// </summary>
	public sealed partial class CleanButton : CleanComponentBase
	{
		/// <inheritdoc cref="ButtonType"/>
		[Parameter]
		public ButtonType ButtonType { get; set; }

		/// <inheritdoc cref="ButtonSize"/>
		[Parameter]
		public ButtonSize Size { get; set; }

		/// <summary>
		/// Whether the button's content consists of only an icon.
		/// </summary>
		/// <remarks>This makes sure that the button scales properly with non-icon-only buttons.</remarks>
		[Parameter]
		public bool IconOnly { get; set; }

		/// <summary>
		/// Whether the button should display a state that indicates that an action is being performed.
		/// </summary>
		[Parameter]
		public bool Loading { get; set; }

		/// <summary>
		/// The main content of the button.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		/// <summary>
		/// The content to show <i>before</i> the main content of the button, like an icon.
		/// </summary>
		[Parameter]
		public RenderFragment? PrefixContent { get; set; }

		/// <summary>
		/// The content to show <i>after</i> the main content of the button, like an icon.
		/// </summary>
		[Parameter]
		public RenderFragment? SuffixContent { get; set; }

		/// <summary>
		/// The <b>prefix</b> to display whenever the button is loading.
		/// </summary>
		/// <remarks>The <see cref="PrefixContent"/> gets replaced with this value whenever the button's <see cref="Loading"/> is <see langword="true"/></remarks>
		[Parameter]
		public RenderFragment? LoadingContent { get; set; }

		/// <summary>
		/// Contains the <c>onclick</c> parameter of the component.
		/// </summary>
		private EventCallback<MouseEventArgs> onClickCallback;

		/// <summary>
		/// The CSS class that represents the given <see cref="ButtonType"/>.
		/// </summary>
		private string TypeClass =>
			(this.ButtonType) switch
			{
				ButtonType.Primary   => "btn-primary",
				ButtonType.Secondary => "btn-secondary",
				ButtonType.Danger    => "btn-danger",
				ButtonType.Link      => "btn-link",
				_                    => "",
			};

		/// <summary>
		/// The CSS class that represents the given <see cref="Size"/>.
		/// </summary>
		private string SizeClass =>
			(this.Size) switch
			{
				ButtonSize.ExtraSmall => "btn-xs",
				ButtonSize.Small      => "btn-sm",
				ButtonSize.Large      => "btn-lg",
				ButtonSize.ExtraLarge => "btn-xl",
				_                     => "",
			};

		/// <inheritdoc/>
		protected override void OnParametersSet() =>
			this.OverrideOnClickCallback();

		/// <summary>
		/// Overrides the <c>onclick</c> parameter of the component, when it has a valid .NET callback.
		/// </summary>
		/// <remarks>This allows the component to directly contain a JavaScript function, or a .NET callback.</remarks>
		private void OverrideOnClickCallback()
		{
			if ((this.AdditionalAttributes?.TryGetValue("onclick", out var onclick) != true) ||
				(onclick is not EventCallback<MouseEventArgs> callback))
			{
				return;
			}

			this.onClickCallback = callback;

			this.AdditionalAttributes["onclick"] = EventCallback.Factory.Create<MouseEventArgs>(this, this.HandleClickAsync);
		}

		/// <summary>
		/// Updates the <see cref="Loading"/> state and invokes the given <c>@onclick</c> parameter.
		/// </summary>
		/// <param name="args">The arguments of the <c>onclick</c> event.</param>
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

	/// <summary>
	/// The type of button to display.
	/// </summary>
	[PublicAPI]
	public enum ButtonType
	{
		/// <summary>
		/// The default button type.
		/// </summary>
		Default,

		/// <summary>
		/// Indicates a primary action, like saving a form.
		/// </summary>
		Primary,

		/// <summary>
		/// Indicates a secondary action, like invoking an alternative action.
		/// </summary>
		Secondary,

		/// <summary>
		/// Indicates a 'dangerous', non-reversible action, like deleting an item.
		/// </summary>
		Danger,

		/// <summary>
		/// Indicates a navigation action.
		/// </summary>
		Link,
	}

	/// <summary>
	/// The size of the button to display.
	/// </summary>
	[PublicAPI]
	public enum ButtonSize
	{
		/// <summary>
		/// The default button size.
		/// </summary>
		Medium,

		/// <summary>
		/// A tiny button.
		/// </summary>
		ExtraSmall,

		/// <summary>
		/// A small button.
		/// </summary>
		Small,

		/// <summary>
		/// A large button.
		/// </summary>
		Large,

		/// <summary>
		/// An extra large button.
		/// </summary>
		ExtraLarge,
	}
}
