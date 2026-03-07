using Elegance.Enums;

namespace CleanUI.Docs.Models
{
	[Enum]
	public enum Theme
	{
		Unknown,
		[EnumValue("dark")] Dark,
		[EnumValue("light")] Light,
	}
}
