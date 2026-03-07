using CleanUI.Docs.Models;
using Microsoft.AspNetCore.Http;

namespace CleanUI.Docs.Extensions
{
	internal static class HttpContextExtensions
	{
		extension(HttpContext context)
		{
			public Theme RequestTheme =>
				context.Request.Cookies.TryGetValue("CleanUI.Theme", out var theme) ? Theme.FromValue(theme) : Theme.Dark;
		}
	}
}
