using System;
using System.Collections.Immutable;
using System.Text;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;

namespace CleanUI.SourceGenerator.Icons
{
	[Generator]
	public sealed class IconsGenerator : IIncrementalGenerator
	{
		public void Initialize(IncrementalGeneratorInitializationContext context)
		{
			var files = context.AdditionalTextsProvider
							   .Where(static (file) => file.Path.EndsWith(".svg", System.StringComparison.Ordinal))
							   .Select(static (file, _) => file.Path)
							   .Collect();

			context.RegisterSourceOutput(files, IconsGenerator.Generate);
		}

		private static void Generate(SourceProductionContext context, ImmutableArray<string> files)
		{
			var icons = IconsGenerator.GetIcons(files);

			var src =
				// language=csharp
				$$"""
				  #nullable enable

				  using Microsoft.AspNetCore.Components;

				  namespace CleanUI
				  {
				  		public static class Icons
				  		{
				  			{{icons}}
				  		}
				  }
				  """;

			context.AddSource("Icons.g.cs", src);
		}

		private static string GetIcons(ImmutableArray<string> files)
		{
			var symbolName = XName.Get("symbol", "http://www.w3.org/2000/svg");

			var builder = new StringBuilder();

			// ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
			foreach (var file in files)
			{
				var document = XDocument.Load(file);

				if (document.Root is null)
				{
					continue;
				}

				var href = IconsGenerator.GetFileHref(file);

				foreach (var symbol in document.Root.Elements(symbolName))
				{
					var id = symbol.Attribute("id");

					if (id is not null)
					{
						builder.Append(IconsGenerator.GetIcon(id.Value, href));
					}
				}
			}

			return builder.ToString();
		}

		private static string GetFileHref(string file)
		{
			const string filePrefix = "wwwroot";
			const string hrefPrefix = "/_content/CleanUI";

			var idx = file.IndexOf(filePrefix, StringComparison.Ordinal);

			if ((idx == -1) || (idx + filePrefix.Length > file.Length))
			{
				throw new Exception($"Can't figure out what the `href` path should be for file: {file}");
			}

			return hrefPrefix + file.Substring(idx + filePrefix.Length);
		}

		private static string GetIcon(string id, string href)
		{
			var name = IconsGenerator.GetIconName(id);

			// language=csharp
			return $$"""
					 public static readonly RenderFragment {{name}} = (builder) =>
					 {
					 		builder.OpenElement(0, "svg");
					 			builder.AddAttribute(1, "viewBox", "0 0 24 24");
					 			builder.AddAttribute(4, "class", "icon");
					 			builder.AddAttribute(5, "aria-hidden", "true");

					 			builder.OpenElement(6, "use");
					 			builder.AddAttribute(7, "href", "{{href}}#{{id}}");
					 			builder.CloseElement();
					 		builder.CloseElement();
					 };

					 """;
		}

		private static string GetIconName(string id)
		{
			Span<char> buffer = stackalloc char[id.Length];

			var written = 0;

			foreach (var part in new SplitEnumerator(id, '-'))
			{
				buffer[written++] = char.ToUpperInvariant(part[0]);

				var copied = part.Slice(1).TryCopyTo(buffer.Slice(written));

				if (!copied)
				{
					throw new Exception();
				}

				written += part.Length - 1;
			}

			return buffer.Slice(0, written).ToString();
		}
	}
}
