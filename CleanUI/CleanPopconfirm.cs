using CleanUI.Internal.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace CleanUI
{
	/// <summary>
	/// A floating element displayed when clicking the trigger's element, that takes user input to execute an action.
	/// </summary>
	public class CleanPopconfirm : CleanComponentBase
	{
		/// <summary>
		/// The position to display the popconfirm at.
		/// </summary>
		[Parameter]
		public PopoverPosition Position { get; set; }

		/// <summary>
		/// The type of the cancel button.
		/// </summary>
		[Parameter]
		public ButtonType CancelButtonType { get; set; } = ButtonType.Default;

		/// <summary>
		/// The size of the cancel button.
		/// </summary>
		[Parameter]
		public ButtonSize CancelButtonSize { get; set; } = ButtonSize.ExtraSmall;

		/// <summary>
		/// The label of the cancel button.
		/// </summary>
		[Parameter]
		public string CancelButtonLabel { get; set; } = "Cancel";

		/// <summary>
		/// The callback to run when the cancel button is clicked.
		/// </summary>
		[Parameter]
		public EventCallback<MouseEventArgs> CancelClicked { get; set; }

		/// <summary>
		/// The type of the OK button.
		/// </summary>
		[Parameter]
		public ButtonType OkButtonType { get; set; } = ButtonType.Danger;

		/// <summary>
		/// The type of the OK button.
		/// </summary>
		[Parameter]
		public ButtonSize OkButtonSize { get; set; } = ButtonSize.ExtraSmall;

		/// <summary>
		/// The type of the OK button.
		/// </summary>
		[Parameter]
		public string OkButtonLabel { get; set; } = "OK";

		/// <summary>
		/// The callback to run when the OK button is clicked.
		/// </summary>
		[Parameter]
		public EventCallback<MouseEventArgs> OkClicked { get; set; }

		/// <summary>
		/// The content of the popconfirm.
		/// </summary>
		[Parameter]
		[EditorRequired]
		public required RenderFragment ChildContent { get; set; }

		/// <summary>
		/// The content of the cancel button.
		/// </summary>
		/// <remarks>This replaces the cancel button entirely and ignores all previous `Cancel…` parameters.</remarks>
		[Parameter]
		public RenderFragment? CancelContent { get; set; }

		/// <summary>
		/// The content of the OK button.
		/// </summary>
		/// <remarks>This replaces the OK button entirely and ignores all previous `Ok…` parameters.</remarks>
		[Parameter]
		public RenderFragment? OkContent { get; set; }

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenComponent<CleanPopover>(0);
			{
				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddComponentParameter(2, nameof(CleanPopover.Position), this.Position);
				builder.AddComponentParameter(3, nameof(CleanPopover.ChildContent), (RenderFragment)this.BuildPopconfirm);
			}
			builder.CloseComponent();
		}

		private void BuildPopconfirm(RenderTreeBuilder builder)
		{
			builder.AddContent(0, this.ChildContent);

			builder.OpenElement(1, "div");
			{
				builder.AddAttribute(2, "class", "popconfirm-actions");

				if (this.CancelContent is not null)
				{
					builder.AddContent(3, this.CancelContent);
				}
				else
				{
					this.BuildButton(builder, this.CancelButtonType, this.CancelButtonSize, this.CancelClicked, this.CancelButtonLabel);
				}

				if (this.OkContent is not null)
				{
					builder.AddContent(4, this.OkContent);
				}
				else
				{
					this.BuildButton(builder, this.OkButtonType, this.OkButtonSize, this.OkClicked, this.OkButtonLabel);
				}
			}
			builder.CloseElement();
		}

		private void BuildButton(RenderTreeBuilder builder,
								 ButtonType type,
								 ButtonSize size,
								 EventCallback<MouseEventArgs> onClick,
								 string label)
		{
			builder.OpenComponent<CleanButton>(0);
			{
				builder.AddComponentParameter(1, nameof(CleanButton.ButtonType), type);
				builder.AddComponentParameter(2, nameof(CleanButton.Size), size);
				builder.AddComponentParameter(3, "onclick", EventCallback.Factory.Create(this, onClick));
				builder.AddComponentParameter(4, nameof(CleanButton.ChildContent), RenderFragment.FromString(label));

				if (this.AdditionalAttributes.GetString("id") is { } id)
				{
					builder.AddComponentParameter(5, "popovertarget", id);
					builder.AddComponentParameter(6, "popovertargetaction", "hide");
				}
			}
			builder.CloseComponent();
		}
	}
}
