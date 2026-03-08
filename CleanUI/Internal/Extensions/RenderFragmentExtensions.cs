using Microsoft.AspNetCore.Components;

namespace CleanUI.Internal.Extensions
{
	internal static class RenderFragmentExtensions
	{
		extension(RenderFragment)
		{
			public static RenderFragment FromString(string content) =>
				(builder) => builder.AddContent(0, content);
		}
	}
}
