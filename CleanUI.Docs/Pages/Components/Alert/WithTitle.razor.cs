using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Alert
{
	public sealed partial class WithTitle : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanAlert>
				<TitleContent>
					<h3>Hello!</h3>
				</TitleContent>
				<ChildContent>
					This alert has a title.
				</ChildContent>
			</CleanAlert>
			
			<CleanAlert ShowIcon>
				<TitleContent>
					Hello!
				</TitleContent>
				<ChildContent>
					This alert has a title AND an icon.
				</ChildContent>
			</CleanAlert>
			
			
			<CleanAlert TitleLevel="@(1)" ShowIcon>
				<TitleContent>
					Hello!
				</TitleContent>
				<ChildContent>
					This alert has a title AND an icon.
				</ChildContent>
			</CleanAlert>
			""";
	}
}
