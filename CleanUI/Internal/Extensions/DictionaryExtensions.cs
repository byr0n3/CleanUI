using System.Collections.Generic;

namespace CleanUI.Internal.Extensions
{
	internal static class DictionaryExtensions
	{
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
