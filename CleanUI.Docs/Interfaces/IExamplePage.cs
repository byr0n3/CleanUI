using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Interfaces
{
	public interface IExamplePage
	{
		public static abstract string Label { get; }

		public static abstract RenderFragment Icon { get; }

		public static abstract string Href { get; }
	}
}
