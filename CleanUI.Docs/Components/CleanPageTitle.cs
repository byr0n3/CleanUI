using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Sections;
using Microsoft.AspNetCore.Components.Web;

namespace CleanUI.Docs.Components
{
	public sealed class CleanPageTitle : ComponentBase
	{
		[Parameter] public RenderFragment? ChildContent { get; set; }

		/// <inheritdoc/>
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenComponent<SectionContent>(0);
			builder.AddComponentParameter(1, nameof(SectionContent.SectionId), CleanPageTitle.GetTitleSectionId(null));
			builder.AddComponentParameter(2, nameof(SectionContent.ChildContent), (RenderFragment)this.BuildTitleRenderTree);
			builder.CloseComponent();
		}

		private void BuildTitleRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "title");
			builder.AddContent(1, this.ChildContent);
			builder.AddContent(2, " • CleanUI");
			builder.CloseElement();
		}

		[UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "TitleSectionId")]
		private static extern ref object GetTitleSectionId(HeadOutlet? headOutlet);
	}
}
