using System;
using System.Linq;
using System.Reflection;
using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;
using NavigationPage = (string Href, string Label, Microsoft.AspNetCore.Components.RenderFragment Icon);

namespace CleanUI.Docs.Components
{
	public sealed partial class Navigation : ComponentBase
	{
		private static readonly NavigationPage[] examplePages = Assembly.GetExecutingAssembly()
																		.GetTypes()
																		.Where(static (t) =>
																				   (t.BaseType == typeof(ComponentBase)) &&
																				   (t.GetInterface(nameof(IExamplePage)) is not null))
																		.Select(Navigation.ToNavigationPage)
																		.OrderBy(static (page) => page.Label, StringComparer.Ordinal)
																		.ToArray();

		private static NavigationPage ToNavigationPage(Type type)
		{
			var href = (string)type.GetProperty(nameof(IExamplePage.Href), BindingFlags.Public | BindingFlags.Static)!
								   .GetValue(null)!;
			var label = (string)type.GetProperty(nameof(IExamplePage.Label), BindingFlags.Public | BindingFlags.Static)!
									.GetValue(null)!;
			var icon = (RenderFragment)type.GetProperty(nameof(IExamplePage.Icon), BindingFlags.Public | BindingFlags.Static)!
										   .GetValue(null)!;

			return (href, label, icon);
		}
	}
}
