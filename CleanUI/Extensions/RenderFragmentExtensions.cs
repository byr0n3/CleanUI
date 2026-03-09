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
		}
	}
}
