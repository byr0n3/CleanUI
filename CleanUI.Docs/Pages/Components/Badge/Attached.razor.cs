using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Badge
{
	public sealed partial class Attached : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton class="p-relative">
				Notifications
				<span class="badge badge-attached color-primary">4</span>
			</CleanButton>
			""";
	}
}
