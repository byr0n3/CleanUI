using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Modal
{
	public sealed partial class PreventClosing : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Button ButtonType="@(ButtonType.Primary)" onclick="window.Modal.open('unclosable-modal')">
				Open unclosable modal
			</Button>

			<Modal Id="unclosable-modal" Closable="false">
				This modal is not closable.
			</Modal>
			""";
	}
}
