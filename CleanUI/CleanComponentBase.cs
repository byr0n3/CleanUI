using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace CleanUI
{
	/// <summary>
	/// Base class of all <c>CleanUI</c> component.
	/// </summary>
	public abstract class CleanComponentBase : ComponentBase
	{
		/// <summary>
		/// Contains every added attribute that isn't captured by a component parameter.
		/// </summary>
		[Parameter(CaptureUnmatchedValues = true)]
		public IDictionary<string, object>? AdditionalAttributes { get; set; }
	}
}
