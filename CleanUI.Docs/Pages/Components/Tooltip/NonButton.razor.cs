using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Tooltip
{
	public sealed partial class NonButton : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton>
				Default
				<CleanTooltip>
					This tooltip is aligned to the top.
				</CleanTooltip>
			</CleanButton>
			""";
	}
}
