using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CleanUI.Internal;
using CleanUI.Internal.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace CleanUI
{
	/// <summary>
	/// A base class for form input components.
	/// </summary>
	/// <typeparam name="TValue">The value of the input component.</typeparam>
	/// <typeparam name="TInput">The actual input component that gets displayed to the user.</typeparam>
	public abstract class CleanInputBase<TValue, TInput> : CleanComponentBase
		where TInput : InputBase<TValue>
	{
		/// <inheritdoc cref="InputBase{TValue}.Value"/>
		[Parameter]
		public TValue? Value { get; set; }

		/// <inheritdoc cref="InputBase{TValue}.ValueChanged"/>
		[Parameter]
		public EventCallback<TValue> ValueChanged { get; set; }

		/// <inheritdoc cref="InputBase{TValue}.ValueExpression"/>
		[Parameter]
		public Expression<Func<TValue>>? ValueExpression { get; set; }

		[Parameter] public string? ContainerClass { get; set; }

		[Parameter] public RenderFragment? PrefixContent { get; set; }

		protected virtual Dictionary<string, object>? ComponentParameters { get; set; }

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "div");
			{
				builder.AddAttribute(1, "class", $"input-container {this.ContainerClass}");

				if (this.PrefixContent is not null)
				{
					builder.OpenElement(2, "span");
					{
						builder.AddAttribute(3, "class", "input-prefix");
						builder.AddContent(4, this.PrefixContent);
					}
					builder.CloseElement();
				}

				builder.OpenComponent<TInput>(5);
				{
					builder.AddMultipleAttributes(6, this.AdditionalParameters);
					builder.AddAttribute(7, nameof(InputBase<>.Value), this.Value);
					builder.AddAttribute(8, nameof(InputBase<>.ValueChanged), this.ValueChanged);
					builder.AddAttribute(9, nameof(InputBase<>.ValueExpression), this.ValueExpression);
					builder.AddAttribute(10, "class", $"input {this.AdditionalParameters.GetString("class")}");
					builder.AddMultipleAttributes(11, this.ComponentParameters);
				}
				builder.CloseComponent();
			}
			builder.CloseElement();
		}
	}
}
