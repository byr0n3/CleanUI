using CleanUI.Internal.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace CleanUI
{
	public class CleanBreadcrumbs : CleanComponentBase
	{
		[Parameter] [EditorRequired] public required string Label { get; set; }

		[Parameter] public string? Divider { get; set; }

		[Parameter] [EditorRequired] public required RenderFragment ChildContent { get; set; }

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "nav");
			{
				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddAttribute(2, "aria-label", this.Label);

				builder.OpenElement(3, "ol");
				{
					if (this.Divider is not null)
					{
						builder.AddAttribute(4, "style", $"--divider:'{this.Divider}'");
					}

					builder.AddAttribute(5, "class", "breadcrumbs");
					builder.AddContent(7, this.ChildContent);
				}
				builder.CloseElement();
			}
			builder.CloseElement();
		}
	}

	public class CleanBreadcrumb : CleanComponentBase
	{
		[Parameter] public string? Href { get; set; }

		[Parameter] public bool Current { get; set; }

		[Parameter] public RenderFragment? IconContent { get; set; }

		[Parameter] public RenderFragment? ChildContent { get; set; }

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "li");
			{
				builder.AddMultipleAttributes(1, this.AdditionalAttributes);
				builder.AddAttribute(2, "class", $"breadcrumb {this.AdditionalAttributes.GetString("class")}");

				if (this.Current)
				{
					builder.AddAttribute(3, "aria-current", "page");
					this.BuildBreadcrumbContent(builder);
				}
				else
				{
					builder.OpenElement(4, "a");
					{
						builder.AddAttribute(5, "href", this.Href);
						this.BuildBreadcrumbContent(builder);
					}
					builder.CloseElement();
				}
			}
			builder.CloseElement();
		}

		private void BuildBreadcrumbContent(RenderTreeBuilder builder)
		{
			if (this.IconContent is not null)
			{
				builder.OpenElement(0, "span");
				{
					builder.AddAttribute(1, "class", "breadcrumb-icon");
					builder.AddContent(2, this.IconContent);
				}
				builder.CloseElement();
			}

			builder.AddContent(3, this.ChildContent);
		}
	}
}
