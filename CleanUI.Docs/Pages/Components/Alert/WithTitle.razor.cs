using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Alert
{
	public sealed partial class WithTitle : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Alert>
				<TitleContent>
					<h3>Hello!</h3>
				</TitleContent>
				<ChildContent>
					This alert has a title.
				</ChildContent>
			</Alert>
			
			<Alert ShowIcon>
				<TitleContent>
					Hello!
				</TitleContent>
				<ChildContent>
					This alert has a title AND an icon.
				</ChildContent>
			</Alert>
			
			
			<Alert TitleLevel="@(1)" ShowIcon>
				<TitleContent>
					Hello!
				</TitleContent>
				<ChildContent>
					This alert has a title AND an icon.
				</ChildContent>
			</Alert>
			""";
	}
}
