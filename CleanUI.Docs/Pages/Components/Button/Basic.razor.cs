using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Button
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Button onclick="alert('Hello world!')">
				Click me!
			</Button>
			""";
	}
}
