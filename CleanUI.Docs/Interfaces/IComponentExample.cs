using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Interfaces
{
	public interface IComponentExample
	{
		public static abstract string Code { get; }

		public static virtual RenderFragment? Description =>
			null;
	}
}
