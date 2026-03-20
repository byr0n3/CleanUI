using System;

namespace CleanUI.Internal.Extensions
{
	internal static class SpanExtensions
	{
		extension<T>(Span<T> span)
		{
			public Span<T> Slice(Range range)
			{
				var (offset, length) = range.GetOffsetAndLength(span.Length);

				return span.Slice(offset, length);
			}
		}

		extension<T>(ReadOnlySpan<T> span)
		{
			public ReadOnlySpan<T> Slice(Range range)
			{
				var (offset, length) = range.GetOffsetAndLength(span.Length);

				return span.Slice(offset, length);
			}
		}
	}
}
