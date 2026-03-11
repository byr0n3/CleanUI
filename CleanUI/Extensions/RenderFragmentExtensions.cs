using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;

namespace CleanUI
{
	[PublicAPI]
	public static class RenderFragmentExtensions
	{
		extension(RenderFragment)
		{
			/// <summary>
			/// An empty <see cref="RenderFragment"/> that renders nothing.
			/// </summary>
			public static RenderFragment Empty => static (_) =>
			{
			};

			/// <summary>
			/// Returns a <see cref="RenderFragment"/>, containing only the given string <paramref name="content"/>.
			/// </summary>
			/// <param name="content">The string content that should be displayed.</param>
			/// <returns>A <see cref="RenderFragment"/>, containing only the given string <paramref name="content"/>.</returns>
			public static RenderFragment FromString(string content) =>
				(builder) => builder.AddContent(0, content);
		}
	}
}
