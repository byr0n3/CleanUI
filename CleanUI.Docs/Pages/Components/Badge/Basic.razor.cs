using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Badge
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<h1>This is a title. <span class="badge">Badge</span></h1>
			<div>This is a message. <span class="badge color-primary">Badge</span></div>
			<div>This is a message. <span class="badge color-secondary">Badge</span></div>
			<div>This is a message. <span class="badge color-info">Badge</span></div>
			<div>This is a message. <span class="badge color-success">Badge</span></div>
			<div>This is a message. <span class="badge color-warning">Badge</span></div>
			<div>This is a message. <span class="badge color-danger">Badge</span></div>
			<div>This is a message. <span class="badge color-disabled">Badge</span></div>
			""";
	}
}
