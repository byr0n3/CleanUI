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
		[Parameter] public bool Striped { get; set; }

		[Parameter] public bool Hoverable { get; set; }

		[Parameter] public bool Bordered { get; set; }

		private bool ShouldAddClasses =>
			this.Striped || this.Hoverable || this.Bordered;

		/// <inheritdoc/>
		protected override void OnParametersSet()
		{
			if (string.Equals(this.Theme, "default", StringComparison.Ordinal))
			{
				this.Theme = "clean";
			}

			if (!this.ShouldAddClasses)
			{
				return;
			}

			this.Class = new ClassList(this.Class)
						 .Add("table-striped", this.Striped)
						 .Add("table-hover", this.Hoverable)
						 .Add("table-border", this.Bordered)
						 .ToString();
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
}
