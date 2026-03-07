using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace CleanUI.Docs.Components
{
	public sealed partial class SwitchThemeButton : ComponentBase
	{
		[CascadingParameter] public required HttpContext HttpContext { get; init; }
	}
}
