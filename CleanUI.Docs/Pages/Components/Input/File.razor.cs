using CleanUI.Docs.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CleanUI.Docs.Pages.Components.Input
{
	public partial class File : ComponentBase, IComponentExample
	{
		public static string Code =>
			// language=razor
			"""
			<CleanUI.InputFile OnChange="@(UpdateFiles)" multiple />

			@if (files is { Count : > 0 })
			{
				<ul>
					@foreach (var file in files)
					{
						<li @key="@($"file-{file.Name}")">
							@(file.Name) (@(file.Size.Str())b)
						</li>
					}
				</ul>
			}

			@code {

				private IReadOnlyList<IBrowserFile>? files;

				private void UpdateFiles(InputFileChangeEventArgs args) =>
					files = args.GetMultipleFiles(5);

			}
			""";
	}
}
