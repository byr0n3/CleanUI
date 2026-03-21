using CleanUI.Internal.Extensions;
using CleanUI.Utilities;
using Microsoft.AspNetCore.Components;

namespace CleanUI
{
	public sealed partial class CleanCard : CleanComponentBase
	{
		[Parameter] public RenderFragment? ImageContent { get; set; }

		[Parameter] public RenderFragment? TitleContent { get; set; }

		[Parameter] public RenderFragment? ChildContent { get; set; }

		[Parameter] public RenderFragment? FooterContent { get; set; }

		[Parameter] public bool Horizontal { get; set; }

		private string Class =>
			new ClassList()
				.Add("card")
				.Add("card-horizontal", this.Horizontal)
				.Add(this.AdditionalAttributes.GetString("class"))
				.ToString();
	}
}
