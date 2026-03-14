using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CleanUI
{
	/// <inheritdoc cref="InputCheckbox"/>
	public sealed partial class CleanInputCheckbox : CleanComponentBase
	{
		/// <inheritdoc cref="InputBase{bool}.Value"/>
		[Parameter]
		public bool Value { get; set; }

		/// <inheritdoc cref="InputBase{bool}.ValueChanged"/>
		[Parameter]
		public EventCallback<bool> ValueChanged { get; set; }

		/// <inheritdoc cref="InputBase{bool}.ValueExpression"/>
		[Parameter]
		public Expression<Func<bool>>? ValueExpression { get; set; }

		/// <inheritdoc cref="CleanInputBase{TValue, TInput}.ContainerClass" />
		[Parameter]
		public string? ContainerClass { get; set; }

		/// <summary>
		/// The label to show for the checkbox.
		/// </summary>
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
	}
}
