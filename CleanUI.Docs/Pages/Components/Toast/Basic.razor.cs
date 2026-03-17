using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Toast
{
	public sealed partial class Basic : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanButton @onclick="@(ShowInfoToast)">
				Show info toast
			</CleanButton>

			<CleanButton @onclick="@(ShowSuccessToast)">
				Show success toast
			</CleanButton>

			<CleanButton @onclick="@(ShowWarningToast)">
				Show warning toast
			</CleanButton>

			<CleanButton @onclick="@(ShowDangerToast)">
				Show danger toast
			</CleanButton>

			@code {

				[Inject] public required IJSRuntime Js { get; init; }

				private void ShowInfoToast(CleanToastType type) =>
					_ = Js.ShowToastAsync(new CleanToastDescriptor(CleanToastType.Info, "Hello world!", "This is a toast notification."));
			
				private void ShowSuccessToast(CleanToastType type) =>
					_ = Js.ShowToastAsync(new CleanToastDescriptor(CleanToastType.Success, "Hello world!", "This is a toast notification."));

				private void ShowWarningToast(CleanToastType type) =>
					_ = Js.ShowToastAsync(new CleanToastDescriptor(CleanToastType.Warning, "Hello world!", "This is a toast notification."));

				private void ShowDangerToast(CleanToastType type) =>
					_ = Js.ShowToastAsync(new CleanToastDescriptor(CleanToastType.Danger, "Hello world!", "This is a toast notification."));

			}
			""";
	}
}
