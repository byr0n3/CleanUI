using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Toast
{
	public sealed partial class WithStaticRendering : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton onclick="@(CleanToast.Show(new CleanToastDescriptor(CleanToastType.Info, "Hello world!", "This is a toast notification.")))">
				Show info toast
			</CleanButton>

			<CleanButton onclick="@(CleanToast.Show(new CleanToastDescriptor(CleanToastType.Success, "Hello world!", "This is a toast notification.")))">
				Show success toast
			</CleanButton>

			<CleanButton onclick="@(CleanToast.Show(new CleanToastDescriptor(CleanToastType.Warning, "Hello world!", "This is a toast notification.")))">
				Show warning toast
			</CleanButton>

			<CleanButton onclick="@(CleanToast.Show(new CleanToastDescriptor(CleanToastType.Danger, "Hello world!", "This is a toast notification.")))">
				Show danger toast
			</CleanButton>
			""";
	}
}
