using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Modal
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Button ButtonType="@(ButtonType.Primary)" onclick="window.Modal.open('basic-modal')">
				Open modal
			</Button>

			<Modal Id="basic-modal" Title="A simple modal!">
				<ChildContent>
					This is the modal's content.
				</ChildContent>
				
				<FooterContent>
					<Button ButtonType="@(ButtonType.Primary)" onclick="window.Modal.close('basic-modal')">
						OK
					</Button>
				</FooterContent>
			</Modal>
			""";
	}
}
