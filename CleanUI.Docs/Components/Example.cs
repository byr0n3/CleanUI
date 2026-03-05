using System;
using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace CleanUI.Docs.Components
{
	public sealed class Example<TComponent> : ComponentBase
		where TComponent : ComponentBase, IComponentExample
	{
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "div");
			{
				Example<TComponent>.AddHeading(builder);

				if (TComponent.Description is not null)
				{
					builder.AddContent(1, TComponent.Description);
				}

				Example<TComponent>.AddComponent(builder);

				Example<TComponent>.AddCode(builder);
			}
			builder.CloseElement();
		}

		private static void AddHeading(RenderTreeBuilder builder)
		{
			var name = typeof(TComponent).Name;

			builder.OpenElement(0, "h2");
			{
				builder.AddContent(1, name);
			}
			builder.CloseElement();
		}

		private static void AddComponent(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "div");
			{
				builder.AddAttribute(1, "class", "mbe-md");
				builder.AddContent(2, static (builder) =>
				{
					builder.OpenComponent<TComponent>(3);
					builder.CloseComponent();
				});
			}
			builder.CloseElement();
		}

		private static void AddCode(RenderTreeBuilder builder)
		{
			var id = Guid.NewGuid().ToString();

			builder.OpenElement(0, "pre");
			{
				builder.OpenElement(1, "code");
				{
					builder.AddAttribute(2, nameof(id), id);
					builder.AddAttribute(3, "class", "hljs language-xml");
					builder.AddAttribute(4, "data-highlighted", "yes");
					builder.AddContent(5, TComponent.Code);
				}
				builder.CloseElement();
			}
			builder.CloseElement();

			builder.OpenElement(6, "script");
			{
				// language=javascript
				builder.AddMarkupContent(7, $$"""
											  document.addEventListener("DOMContentLoaded", () => {
											    const element = document.getElementById('{{id}}');
											  	element.innerHTML = hljs.highlight(`{{TComponent.Code}}`, {language: 'xml'}).value;
											  });
											  """);
			}
			builder.CloseElement();
		}
	}
}
