using System.Diagnostics.CodeAnalysis;
using CleanUI.Internal.Extensions;
using CleanUI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace CleanUI
{
	/// <summary>
	/// A component used to display the loading state of a page or section.
	/// </summary>
	public class CleanSpinner : CleanComponentBase
	{
		/// <summary>
		/// The default <see cref="SpinnerContent"/> to show when none is set.
		/// </summary>
		[SuppressMessage("Usage", "CA2211")]
		[SuppressMessage("Design", "MA0069")]
		public static RenderFragment Default = Icons.Reload;

		/// <summary>
		/// Whether to currently show the spinning indicator.
		/// </summary>
		[Parameter]
		public bool Spinning { get; set; } = true;

		/// <summary>
		/// The optional child content to render underneath the spinner.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		/// <summary>
		/// Optionally replaces the default spinner to show.
		/// </summary>
		[Parameter]
		public RenderFragment? SpinnerContent { get; set; }

		/// <inheritdoc />
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			if (this.ChildContent is null)
			{
				if (this.Spinning)
				{
					this.BuildSpinner(builder, true);
				}

				return;
			}

			builder.OpenElement(0, "div");
			{
				var classes = new ClassList()
							  .Add("spinner-content-container")
							  .Add("spinner-spinning", this.Spinning)
							  .Add(this.AdditionalAttributes.GetString("class"))
							  .ToString();

				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddAttribute(2, "class", classes);
				builder.AddAttribute(3, "aria-busy", this.Spinning);

				builder.OpenElement(4, "div");
				{
					builder.AddAttribute(5, "class", "spinner-container");
					this.BuildSpinner(builder);
				}
				builder.CloseElement();

				builder.OpenElement(6, "div");
				{
					builder.AddAttribute(7, "class", "spinner-content");
					builder.AddContent(8, this.ChildContent);
				}
				builder.CloseElement();
			}
			builder.CloseElement();
		}

		/// <summary>
		/// Adds the spinner element to the <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The builder to add the spinner to.</param>
		/// <param name="addAttributes">Whether to append all <see cref="CleanSpinner.AdditionalAttributes"/> to the element.</param>
		private void BuildSpinner(RenderTreeBuilder builder, bool addAttributes = false)
		{
			var classes = new ClassList()
						  .Add("spinner")
						  .Add("spinner-spinning", this.Spinning)
						  .Add(this.AdditionalAttributes.GetString("class"), addAttributes)
						  .ToString();

			builder.OpenElement(0, "div");
			{
				if (addAttributes)
				{
					builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				}

				builder.AddAttribute(2, "class", classes);
				builder.AddAttribute(3, "aria-busy", this.Spinning);
				builder.AddContent(4, this.SpinnerContent ?? CleanSpinner.Default);
			}
			builder.CloseElement();
		}
	}
}
