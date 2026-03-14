using System;
using Microsoft.AspNetCore.Components;

namespace CleanUI
{
	// @todo Create `CleanDialog` component, exended `CleanModal` from that
	/// <summary>
	/// A popup-window that's displayed on top of all other site content.
	/// </summary>
	public sealed partial class CleanModal : CleanComponentBase
	{
		/// <summary>
		/// The ID of the modal.
		/// </summary>
		[Parameter]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		/// <summary>
		/// The title of the modal.
		/// </summary>
		/// <remarks>This value is only shown when <see cref="HeaderContent"/> is <see langword="null"/>.</remarks>
		[Parameter]
		public string? Title { get; set; }

		/// <summary>
		/// Whether the modal is closable or not.
		/// </summary>
		/// <remarks>
		/// If this value is <see langword="false"/>, the modal can still be closed using the JS function <c>window.Modal.close</c>.
		/// </remarks>
		[Parameter]
		public bool Closable { get; set; } = true;

		/// <summary>
		/// The content of the modal's header.
		/// </summary>
		/// <remarks>This value overrides the given <see cref="Title"/>.</remarks>
		[Parameter]
		public RenderFragment? HeaderContent { get; set; }

		/// <summary>
		/// The content of the modal's body.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		/// <summary>
		/// The content of the modal's footer.
		/// </summary>
		[Parameter]
		public RenderFragment? FooterContent { get; set; }
	}
}
