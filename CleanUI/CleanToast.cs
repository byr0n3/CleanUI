using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Elegance.Enums;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CleanUI
{
	public static class CleanToast
	{
		extension(IJSRuntime js)
		{
			/// <summary>
			/// Shows a toast to the user.
			/// </summary>
			/// <param name="descriptor">The descriptor that describes the toast to show.</param>
			/// <param name="token">Cancellation token to cancel the async-operation.</param>
			/// <returns>A <see cref="ValueTask"/> that completes when the <c>window.Toast.show</c> function was called on the client-side.</returns>
			public ValueTask ShowToastAsync(CleanToastDescriptor descriptor, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Toast.show", token, descriptor);

			/// <summary>
			/// Removes a shown toast.
			/// </summary>
			/// <param name="id">The ID of the toast to remove.</param>
			/// <param name="token">Cancellation token to cancel the async-operation.</param>
			/// <returns>A <see cref="ValueTask"/> that completes when the <c>window.Toast.remove</c> function was called on the client-side.</returns>
			public ValueTask RemoveToastAsync(string id, CancellationToken token = default) =>
				js.InvokeVoidAsync("window.Toast.remove", token, id);
		}

		extension(CleanToastType type)
		{
			/// <summary>
			/// Gets a fitting icon for this type.
			/// </summary>
			/// <returns>An icon that matches this type.</returns>
			public RenderFragment GetIcon() =>
				(type) switch
				{
					CleanToastType.Success => Icons.CircleCheck,
					CleanToastType.Warning => Icons.AlertTriangle,
					CleanToastType.Danger  => Icons.AlertCircle,
					_                      => Icons.InfoCircle,
				};
		}

		public static string Show(CleanToastDescriptor descriptor)
		{
			var serialized = JsonSerializer.Serialize(descriptor);

			return $"window.Toast.show({serialized})";
		}

		public static string Hide(string id) =>
			$"window.Toast.hide('{id}')";
	}

	/// <summary>
	/// Describes a toast that should be displayed.
	/// </summary>
	[PublicAPI]
	[JsonConverter(typeof(JsonCleanToastDescriptorConverter))]
	public readonly struct CleanToastDescriptor
	{
		public static readonly TimeSpan DefaultDuration = TimeSpan.FromSeconds(5);

		/// <inheritdoc cref="CleanToastType" />
		/// <remarks>This value is used to indicate the icon of the toast.</remarks>
		public CleanToastType Type { get; init; }

		/// <summary>
		/// The title of the toast.
		/// </summary>
		public string? Title { get; init; }

		/// <summary>
		/// The main message of the toast.
		/// </summary>
		public string? Body { get; init; }

		/// <summary>
		/// How long the toast should be displayed for.
		/// </summary>
		/// <remarks>
		/// <p>The default value is 5 seconds.</p>
		/// <p>A value lower than <c>0</c> indicates a toast that shouldn't automatically disappear.</p>
		/// </remarks>
		public TimeSpan Duration { get; init; }

		/// <summary>
		/// The ID of the toast.
		/// </summary>
		/// <remarks>This ID is generated dynamically and is used to close a toast manually.</remarks>
		public readonly string Id;

		/// <inheritdoc cref="CleanToastDescriptor"/>
		/// <param name="type">The type of toast to display.</param>
		/// <param name="title">The title of the toast.</param>
		/// <param name="body">The main message of the toast.</param>
		/// <param name="duration">How long the toast should be displayed for.</param>
		/// <remarks>
		/// <p>The default <paramref name="duration"/> is 5 seconds.</p>
		/// <p>A <paramref name="duration"/> lower than <c>0</c> indicates a toast that shouldn't automatically disappear.</p>
		/// </remarks>
		public CleanToastDescriptor(CleanToastType type = default,
									string? title = null,
									string? body = null,
									TimeSpan? duration = null)
		{
			this.Id = Guid.NewGuid().ToString();

			this.Type = type;
			this.Title = title;
			this.Body = body;
			this.Duration = duration ?? CleanToastDescriptor.DefaultDuration;
		}
	}

	/// <summary>
	/// The type of toast to display.
	/// </summary>
	[Enum]
	[PublicAPI]
	public enum CleanToastType
	{
		[EnumValue("info")] Info,
		[EnumValue("success")] Success,
		[EnumValue("warning")] Warning,
		[EnumValue("danger")] Danger,
	}

	internal sealed class JsonCleanToastDescriptorConverter : JsonConverter<CleanToastDescriptor>
	{
		private static readonly JsonCleanToastTypeConverter typeConverter = new();

		public override CleanToastDescriptor Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options) =>
			throw new NotSupportedException();

		public override void Write(Utf8JsonWriter writer, CleanToastDescriptor value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();
			{
				writer.WriteString("id"u8, value.Id);

				if (value.Type != default)
				{
					writer.WritePropertyName("type"u8);
					JsonCleanToastDescriptorConverter.typeConverter.Write(writer, value.Type, options);
				}

				if (value.Title is not null)
				{
					writer.WriteString("title"u8, value.Title);
				}

				if (value.Body is not null)
				{
					writer.WriteString("body"u8, value.Body);
				}

				writer.WriteNumber("duration"u8, (int)double.Round(value.Duration.TotalMilliseconds));
			}
			writer.WriteEndObject();
		}
	}
}
