using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Internal
{
	public abstract class CleanComponentBase : ComponentBase
	{
		[Parameter(CaptureUnmatchedValues = true)]
		public IDictionary<string, object?>? AdditionalParameters { get; set; }
	}
}
