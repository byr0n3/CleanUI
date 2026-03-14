using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Button
{
	public sealed partial class IconOnly : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton IconOnly>
				@(Icons.User)
			</CleanButton>
			
			<CleanButton ButtonType="@(ButtonType.Primary)" IconOnly>
				@(Icons.User)
			</CleanButton>
			
			<CleanButton ButtonType="@(ButtonType.Secondary)" IconOnly>
				@(Icons.User)
			</CleanButton>
			
			<CleanButton ButtonType="@(ButtonType.Danger)" IconOnly>
				@(Icons.User)
			</CleanButton>
			
			<CleanButton ButtonType="@(ButtonType.Link)" IconOnly>
				@(Icons.User)
			</CleanButton>
			""";
	}
}
