using System;
using CleanUI.Internal;
using Microsoft.AspNetCore.Components;

namespace CleanUI
{
	public sealed partial class Modal : CleanComponentBase
	{
		[Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();

		[Parameter] public string? Title { get; set; }

		[Parameter] public RenderFragment? HeaderContent { get; set; }

		[Parameter] public RenderFragment? ChildContent { get; set; }

		[Parameter] public RenderFragment? FooterContent { get; set; }
	}
}
