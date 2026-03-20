using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Spinner
{
	public sealed partial class WithContent : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanSpinner Spinning id="spinner">
				<CleanAlert>
					<TitleContent>
						A very useless alert
					</TitleContent>

					<ChildContent>
						You probably can only read this when the spinner stops spinning, otherwise the blur might have to be
						adjusted.
					</ChildContent>
				</CleanAlert>
			</CleanSpinner>
			""";
	}
}
