using System;
using System.Collections.Generic;

namespace CleanUI.Internal.Extensions
{
	internal static class DictionaryExtensions
	{
		extension(Dictionary<string, object>? dictionary)
		{
			public object? Get(string key) =>
				dictionary?.TryGetValue(key, out var value) == true ? value : null;

			public string? GetString(string key) =>
				(string?)dictionary.Get(key);

			public bool GetBoolean(string key) =>
				((bool?)dictionary.Get(key)) ?? false;
		}

		extension(IDictionary<string, object> dictionary)
		{
			public void Inject(string key, string value)
			{
				if (!dictionary.TryGetValue(key, out var current))
				{
					dictionary[key] = value;
					return;
				}

				if (current is string @string)
				{
					if (!@string.Contains(value, StringComparison.Ordinal))
					{
						dictionary[key] = $"{value} {@string}";
					}
				}
				else
				{
					dictionary[key] = $"{value} {current}";
				}
			}
		}

		extension(IDictionary<string, object>? dictionary)
		{
			public object? Get(string key) =>
				dictionary?.TryGetValue(key, out var value) == true ? value : null;

			public string? GetString(string key) =>
				(string?)dictionary.Get(key);

			public bool GetBoolean(string key) =>
				((bool?)dictionary.Get(key)) ?? false;
		}

		extension(IReadOnlyDictionary<string, object>? dictionary)
		{
			public object? Get(string key) =>
				dictionary?.TryGetValue(key, out var value) == true ? value : null;

			public string? GetString(string key) =>
				(string?)dictionary.Get(key);

			public bool GetBoolean(string key) =>
				((bool?)dictionary.Get(key)) ?? false;
		}
	}
}
