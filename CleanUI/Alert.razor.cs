using CleanUI.Internal;
using Microsoft.AspNetCore.Components;

namespace CleanUI
{
	public sealed partial class Alert : CleanComponentBase
	{
		[Parameter] public AlertType Type { get; set; }

		[Parameter] public RenderFragment? ChildContent { get; set; }

		private string TypeClass =>
			(this.Type) switch
			{
				AlertType.Info    => "alert-info",
				AlertType.Success => "alert-success",
				AlertType.Warning => "alert-warning",
				AlertType.Danger  => "alert-danger",
				_                 => "",
			};
	}

	public enum AlertType
	{
		Default,
		Info,
		Success,
		Warning,
		Danger
	}
}
