![CleanUI icon](./icon.png)

# CleanUI

A modern, clean and elegant UI library for Blazor/Razor.

## Usage

1. Add the `CleanUI` package:

```shell
dotnet add package CleanUI
```

or

```xml
<ItemGroup>
	<PackageVersion Include="CleanUI" Version="0.1.0"/>
</ItemGroup>
```

2. Add the following lines to your `App.razor`:

```razor
<!-- CSS variables (required) (can be overwritten) -->
<link rel="stylesheet" href="@(Assets["_content/CleanUI/theme.css"])"/>
<!-- Base styling for components (required) -->
<link rel="stylesheet" href="@(Assets["_content/CleanUI/base.css"])"/>
<!-- Reset styling (html, body, etc.) (optional) -->
<link rel="stylesheet" href="@(Assets["_content/CleanUI/reset.css"])"/>
<!-- Utility classes (things like spacing, font size, etc.) (optional) -->
<link rel="stylesheet" href="@(Assets["_content/CleanUI/utilities.css"])"/>
```

3. Use the components:

```razor
<CleanUI.CleanButton>
	Click me!
</CleanUI.CleanButton>
```

or

```razor
@using CleanUI

<CleanButton>
	Click me!
</CleanButton>
```
