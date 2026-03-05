using System;
using System.Runtime.InteropServices;

namespace CleanUI.SourceGenerator.Icons
{
	[StructLayout(LayoutKind.Sequential)]
	internal ref struct SplitEnumerator
	{
		private readonly ReadOnlySpan<char> source;
		private readonly char separator;

		private int position;
		private int current;
		private int length;

		public readonly ReadOnlySpan<char> Current =>
			this.source.Slice(this.position, this.length);

		public SplitEnumerator(ReadOnlySpan<char> source, char separator)
		{
			this.source = source;
			this.separator = separator;
		}

		public bool MoveNext()
		{
			if (this.current >= this.source.Length)
			{
				return false;
			}

			this.length = this.source.Slice(this.current).IndexOf(this.separator);

			this.position = this.current;

			if (this.length != -1)
			{
				this.current = this.position + this.length + 1;
			}
			else
			{
				this.length = this.source.Length - this.position;
				this.current = this.source.Length;
			}

			return true;
		}

		public readonly SplitEnumerator GetEnumerator() =>
			this;
	}
}
