using System;
using System.Collections.Generic;
using CleanUI.Internal.Extensions;

namespace CleanUI.Utilities
{
	public sealed class ClassList
	{
		private readonly List<string> classes;

		public ClassList() =>
			this.classes = [];

		public ClassList(string? classes) =>
			this.classes = ClassList.SplitClasses(classes);

		public ClassList Add(string? @class, bool add = true)
		{
			if (add && (@class is not null)&& !this.classes.Contains(@class))
			{
				this.classes.Add(@class);
			}

			return this;
		}

		public override string ToString() =>
			string.Join(' ', this.classes);

		private static List<string> SplitClasses(scoped ReadOnlySpan<char> classes)
		{
			if (classes.IsEmpty)
			{
				return [];
			}

			var result = new List<string>();

			foreach (var range in classes.Split(' '))
			{
				var part = classes.Slice(range);

				Trim(ref part);

				result.Add(part.ToString());
			}

			return result;

			static void Trim(ref ReadOnlySpan<char> span)
			{
				while (span[0] == ' ')
				{
					span = span.Slice(1);
				}

				while (span[^1] == ' ')
				{
					span = span.Slice(0, span.Length - 1);
				}
			}
		}
	}
}
