using System;
using System.Linq.Expressions;
using CleanUI.Internal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CleanUI
{
	public sealed partial class InputCheckbox : CleanComponentBase
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

		[Parameter] public string? ContainerClass { get; set; }

		[Parameter] public RenderFragment? ChildContent { get; set; }
	}
}
