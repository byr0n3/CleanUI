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
		/// <inheritdoc/>
		protected override void OnParametersSet()
		{
			if (string.Equals(this.Theme, "default", StringComparison.Ordinal))
			{
				this.Theme = "clean";
			}
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
