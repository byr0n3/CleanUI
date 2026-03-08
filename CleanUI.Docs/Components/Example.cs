using System;
using System.Text;
using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace CleanUI.Docs.Components
{
	public sealed class Example<TComponent> : ComponentBase
		where TComponent : ComponentBase, IComponentExample
	{
		private readonly NavigationManager navigation;

		public Example(NavigationManager navigation) =>
			this.navigation = navigation;

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "div");
			{
				this.AddHeading(builder);

				if (TComponent.Description is not null)
				{
					builder.AddContent(1, TComponent.Description);
				}

				Example<TComponent>.AddComponent(builder);

				Example<TComponent>.AddCode(builder);
			}
			builder.CloseElement();
		}

		private void AddHeading(RenderTreeBuilder builder)
		{
			var name = Example<TComponent>.NameToTitleCase();
			var id = Example<TComponent>.NameToSnakeCase();

			builder.OpenElement(0, "h2");
			{
				builder.AddAttribute(1, "id", id);
				builder.AddContent(2, (RenderFragment)((anchorBuilder) =>
				{
					anchorBuilder.OpenElement(0, "a");
					{
						builder.AddAttribute(1, "href", $"{this.navigation.Uri}#{id}");
						builder.AddAttribute(2, "class", "fs-sm");
						builder.AddContent(3, Icons.Hash);
					}
					anchorBuilder.CloseElement();
				}));
				builder.AddContent(3, name);
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
			if (TComponent.Code is null)
			{
				return;
			}

			builder.OpenElement(0, "pre");
			{
				builder.OpenElement(1, "code");
				{
					builder.AddContent(2, TComponent.Code);
				}
				builder.CloseElement();
			}
			builder.CloseElement();
		}

		private static string NameToTitleCase()
		{
			var span = typeof(TComponent).Name.AsSpan();
			var builder = new StringBuilder();

			foreach (var @char in span)
			{
				if (builder.Length != 0 && char.IsUpper(@char))
				{
					builder.Append(' ');
				}

				builder.Append(@char);
			}

			return builder.ToString();
		}

		private static string NameToSnakeCase()
		{
			var span = typeof(TComponent).Name.AsSpan();
			var builder = new StringBuilder();

			foreach (var @char in span)
			{
				if (builder.Length != 0 && char.IsUpper(@char))
				{
					builder.Append('-');
				}

				builder.Append(char.ToLowerInvariant(@char));
			}

			return builder.ToString();
		}
	}
}
