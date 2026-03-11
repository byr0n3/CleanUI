using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanUI.Utilities
{
	/// <summary>
	/// Utilities for working with debounced functions.
	/// </summary>
	public static class Debounce
	{
		public static readonly TimeSpan DefaultDelay = TimeSpan.FromMilliseconds(300);

		/// <summary>
		/// Creates a new callback that handles calling a function debounced.
		/// </summary>
		/// <param name="callback">The callback to trigger.</param>
		/// <param name="delay">The debounce delay. Default is 300ms.</param>
		/// <returns>A debounced callback function.</returns>
		public static Func<Task> Create(Func<Task> callback, TimeSpan delay = default)
		{
			if (delay == default)
			{
				delay = Debounce.DefaultDelay;
			}

			CancellationTokenSource? cts = null;

			return async () =>
			{
				try
				{
					if (cts is not null)
					{
						await cts.CancelAsync().ConfigureAwait(false);
						cts.Dispose();
					}

					cts = new CancellationTokenSource();

					var token = cts.Token;

					await Task.Delay(delay, token).ConfigureAwait(false);

					if (!token.IsCancellationRequested)
					{
						await callback().ConfigureAwait(false);
					}
				}
				catch (OperationCanceledException)
				{
				}
			};
		}

		/// <inheritdoc cref="Create" />
		/// <typeparam name="TParam">The type of the parameter to pass along.</typeparam>
		public static Func<TParam, Task> Create<TParam>(Func<TParam, Task> callback, TimeSpan delay = default)
		{
			if (delay == default)
			{
				delay = Debounce.DefaultDelay;
			}

			CancellationTokenSource? cts = null;

			return async (param) =>
			{
				try
				{
					if (cts is not null)
					{
						await cts.CancelAsync().ConfigureAwait(false);
						cts.Dispose();
					}

					cts = new CancellationTokenSource();

					var token = cts.Token;

					await Task.Delay(delay, token).ConfigureAwait(false);

					if (!token.IsCancellationRequested)
					{
						await callback(param).ConfigureAwait(false);
					}
				}
				catch (OperationCanceledException)
				{
				}
			};
		}
	}
}
