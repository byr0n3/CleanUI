using Elegance.Extensions;
using Microsoft.AspNetCore.Components;

namespace CleanUI
{
	/// <summary>
	/// A banner-like component that can communicate an important message or status update.
	/// </summary>
	public partial class CleanAlert : CleanComponentBase
	{
		/// <inheritdoc cref="CleanAlertType"/>
		[Parameter]
		public CleanAlertType Type { get; set; }

		/// <summary>
		/// Whether the alert should display an icon.
		/// </summary>
		[Parameter]
		public bool ShowIcon { get; set; }

		/// <summary>
		/// The level of the title heading.
		/// </summary>
		/// <remarks>Defaults to <c>h4</c>.</remarks>
		[Parameter]
		public int TitleLevel { get; set; } = 4;

		/// <summary>
		/// The icon to display in the alert.
		/// </summary>
		/// <remarks>
		/// <p>If this value contains a non-null value, the icon will be displayed no matter the value of <see cref="ShowIcon"/>.</p>
		/// <p>
		/// If this value is <see langword="null"/>, but <see cref="ShowIcon"/> is <see langword="true"/>,
		/// the displayed icon will be based off of the given <see cref="Type"/>.
		/// </p>
		/// </remarks>
		[Parameter]
		public RenderFragment? IconContent { get; set; }

		/// <summary>
		/// The content of the alert's title.
		/// </summary>
		/// <remarks>If this value is <see langword="null"/>, no title will be displayed.</remarks>
		[Parameter]
		public RenderFragment? TitleContent { get; set; }

		/// <summary>
		/// The message of the alert.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		/// <summary>
		/// The icon to display in the alert.
		/// </summary>
		private RenderFragment Icon =>
			this.IconContent ?? CleanAlert.GetAlertTypeIcon(this.Type);

		/// <summary>
		/// The CSS class that represents the given <see cref="Type"/>.
		/// </summary>
		private string TypeClass =>
			(this.Type) switch
			{
				CleanAlertType.Success   => "alert-success",
				CleanAlertType.Warning   => "alert-warning",
				CleanAlertType.Danger    => "alert-danger",
				CleanAlertType.Primary   => "alert-primary",
				CleanAlertType.Secondary => "alert-secondary",
				_                        => "alert-info",
			};

		/// <summary>
		/// The title element to display in the alert.
		/// </summary>
		private RenderFragment Title =>
			(builder) =>
			{
				var headingSize = int.Clamp(this.TitleLevel, 1, 6);

				builder.OpenElement(0, $"h{headingSize.Str()}");
				{
					builder.AddAttribute(1, "class", "alert-title");

					if (this.ShowIcon || (this.IconContent is not null))
					{
						builder.AddContent(2, this.Icon);
					}

					builder.AddContent(3, this.TitleContent);
				}
				builder.CloseElement();
			};

		/// <summary>
		/// Returns a fitting icon based on the given <paramref name="type"/>.
		/// </summary>
		/// <param name="type">The <see cref="CleanAlertType"/> to get a fitting icon for.</param>
		/// <returns>An icon that matches the value of <paramref name="type"/>.</returns>
		private static RenderFragment GetAlertTypeIcon(CleanAlertType type) =>
			(type) switch
			{
				CleanAlertType.Success => Icons.CircleCheck,
				CleanAlertType.Warning => Icons.AlertTriangle,
				CleanAlertType.Danger  => Icons.AlertCircle,
				_                      => Icons.InfoCircle,
			};
	}

	/// <summary>
	/// The type of alert to display.
	/// </summary>
	public enum CleanAlertType
	{
		/// <summary>
		/// An informational message.
		/// </summary>
		Info,

		/// <summary>
		/// A message that indicates an action was performed, like 'item saved successfully'.
		/// </summary>
		Success,

		/// <summary>
		/// A message that indicates a potential issue or noteworthy message, like 'item relation missing'.
		/// </summary>
		Warning,

		/// <summary>
		/// A message that indicates that something went wrong, like 'failed to save item'.
		/// </summary>
		Danger,

		Primary,
		Secondary,
	}
}
