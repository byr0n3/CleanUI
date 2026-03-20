using System;
using CleanUI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components.Rendering;

namespace CleanUI
{
	/// <inheritdoc/>
	[CascadingTypeParameter(nameof(TGridItem))]
	public class CleanTable<TGridItem> : QuickGrid<TGridItem>
	{
		/// <summary>
		/// Whether the table should have striped rows.
		/// </summary>
		[Parameter]
		public bool Striped { get; set; }

		/// <summary>
		/// Whether the table's rows should be hoverable.
		/// </summary>
		[Parameter]
		public bool Hoverable { get; set; }

		/// <summary>
		/// Whether the table should be fully bordered.
		/// </summary>
		[Parameter]
		public bool Bordered { get; set; }

		/// <summary>
		/// Whether the table should have no borders whatsoever.
		/// </summary>
		[Parameter]
		public bool Borderless { get; set; }

		/// <inheritdoc cref="CleanTableSize" />
		[Parameter]
		public CleanTableSize Size { get; set; }

		/// <inheritdoc cref="CleanTableResponsiveness" />
		[Parameter]
		public CleanTableResponsiveness Responsiveness { get; set; }

		/// <inheritdoc/>
		protected override void OnParametersSet()
		{
			if (string.Equals(this.Theme, "default", StringComparison.Ordinal))
			{
				this.Theme = "clean";
			}

			var classes = new ClassList(this.Class).Add("table");

			classes.Add("table-striped", this.Striped)
				   .Add("table-hover", this.Hoverable)
				   .Add("table-border", this.Bordered)
				   .Add("table-borderless", this.Borderless);

			if (this.Size == CleanTableSize.Small)
			{
				classes.Add("table-sm");
			}
			else if (this.Size == CleanTableSize.Large)
			{
				classes.Add("table-lg");
			}

			this.Class = classes.ToString();
		}

		/// <inheritdoc/>
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			if (this.Responsiveness == CleanTableResponsiveness.None)
			{
				base.BuildRenderTree(builder);
				return;
			}

			var @class = (this.Responsiveness) switch
			{
				CleanTableResponsiveness.Always     => "table-responsive",
				CleanTableResponsiveness.ExtraSmall => "table-responsive-xs",
				CleanTableResponsiveness.Small      => "table-responsive-sm",
				CleanTableResponsiveness.Medium     => "table-responsive-md",
				CleanTableResponsiveness.Large      => "table-responsive-lg",
				CleanTableResponsiveness.ExtraLarge => "table-responsive-xl",
				_                                   => null,
			};

			builder.OpenElement(0, "div");
			{
				builder.AddAttribute(1, "class", @class);
				base.BuildRenderTree(builder);
			}
			builder.CloseElement();
		}
	}

	/// <inheritdoc/>
	public class CleanPropertyColumn<TGridItem, TProp> : PropertyColumn<TGridItem, TProp>
	{
		[Parameter] public RenderFragment<TProp>? ChildContent { get; set; }

		/// <inheritdoc cref="ComponentBase.OnParametersSet"/>
		protected override void OnParametersSet()
		{
			this.Title ??= DisplayName.Get(this.Property);

			base.OnParametersSet();
		}

		/// <inheritdoc cref="ColumnBase{TGridItem}.CellContent"/>
		protected override void CellContent(RenderTreeBuilder builder, TGridItem item)
		{
			if (this.ChildContent is null)
			{
				base.CellContent(builder, item);
			}
			else
			{
				var prop = this.Property.Compile().Invoke(item);

				builder.AddContent(0, this.ChildContent(prop));
			}
		}
	}

	/// <summary>
	/// The size of the table to display
	/// </summary>
	public enum CleanTableSize
	{
		Default,
		Small,
		Large,
	}

	/// <summary>
	/// When the table should be responsive.
	/// </summary>
	public enum CleanTableResponsiveness
	{
		None,
		Always,
		ExtraSmall,
		Small,
		Medium,
		Large,
		ExtraLarge,
	}
}
