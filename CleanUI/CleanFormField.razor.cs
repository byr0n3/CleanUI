using System;
using System.Linq.Expressions;
using CleanUI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CleanUI
{
	/// <summary>
	/// A block that displays an input for a field with a label and optionally an error message and/or assistance text.
	/// </summary>
	public sealed partial class CleanFormField : CleanComponentBase
	{
		/// <summary>
		/// When this component is a child of a form, it will attach an <c>EditContext</c> parameter.
		/// </summary>
		[CascadingParameter]
		public EditContext? EditContext { get; set; }

		/// <summary>
		/// The content of the form field, likely an input component.
		/// </summary>
		[Parameter]
		[EditorRequired]
		public required RenderFragment ChildContent { get; set; }

		/// <summary>
		/// The property this form field represents.
		/// </summary>
		/// <remarks>
		/// Use this parameter to automatically use the property's display name for the label and show the current validation message if there is any.
		/// </remarks>
		[Parameter]
		public Expression<Func<object?>>? Property { get; set; }

		/// <summary>
		/// The content to show as the label for the field.
		/// </summary>
		/// <remarks>This takes priority over the display name of the given <see cref="Property"/>.</remarks>
		[Parameter]
		public RenderFragment? LabelContent { get; set; }

		/// <summary>
		/// Additional `help` text to show underneath the field's <see cref="ChildContent"/>.
		/// </summary>
		[Parameter]
		public RenderFragment? HelpContent { get; set; }

		/// <summary>
		/// A manual, custom error show in the error list.
		/// </summary>
		/// <remarks>This <b>doesn't</b> overwrite the displayed validation messages of the form, only adds to it.</remarks>
		[Parameter]
		public RenderFragment? ErrorContent { get; set; }

		/// <summary>
		/// Whether to hide the input's label.
		/// </summary>
		[Parameter]
		public bool HideLabel { get; set; }

		/// <summary>
		/// Whether to show the input's label inline with the input.
		/// </summary>
		[Parameter] public bool Inline { get; set; }

		/// <summary>
		/// The current label content, based on multiple parameters.
		/// </summary>
		private RenderFragment Label =>
			this.LabelContent ??
			(this.Property is not null ? RenderFragment.FromString(DisplayName.Get(this.Property)) : RenderFragment.Empty);
	}
}
