using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace CleanUI.Utilities
{
	/// <summary>
	/// Utilities for retrieving display names of properties/expressions.
	/// </summary>
	public static class DisplayName
	{
		/// <summary>
		/// Get the configured display name of the given <paramref name="lambda"/>.
		/// </summary>
		/// <param name="lambda">The expression that returns the property to get the display name of.</param>
		/// <returns>The configured display name of the property, or the name of the property when no display name attribute was found.</returns>
		/// <exception cref="ArgumentException">Thrown when an unknown <see cref="LambdaExpression"/> was given.</exception>
		/// <remarks>
		/// This method returns either the configured <see cref="DisplayAttribute"/>'s name or the configured <see cref="DisplayNameAttribute"/>'s display name.
		/// </remarks>
		public static string Get(LambdaExpression lambda)
		{
			if (lambda.Body is MemberExpression member)
			{
				return member.Member.GetCustomAttribute<DisplayAttribute>()?.GetName() ??
					   member.Member.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ??
					   member.Member.Name;
			}

			throw new ArgumentException($"Invalid lambda expression of type: {lambda.GetType().Name}", nameof(lambda));
		}
	}
}
