using System;
using System.Threading.Tasks;
using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Button
{
	public sealed partial class Loading : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<Button @onclick="@(OnClickAsync)">
				Click me!
			</Button>
			
			<Button Loading>
				Loading…
			</Button>

			@code {
				private static Task OnClickAsync() =>
					Task.Delay(TimeSpan.FromSeconds(1));
			}
			""";

		private static Task OnClickAsync() =>
			Task.Delay(TimeSpan.FromSeconds(1));
	}
}
