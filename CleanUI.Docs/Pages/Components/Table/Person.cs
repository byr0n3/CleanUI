using System;
using System.ComponentModel.DataAnnotations;

namespace CleanUI.Docs.Pages.Components.Table
{
	internal readonly record struct Person
	{
		[Display(Name = "Id")] public readonly int Id;
		public readonly string GivenName;
		public readonly string FamilyName;
		[Display(Name = "Birthday")] public readonly DateOnly DateOfBirth;
		[Display(Name = "E-mail")] public readonly string Email;
		[Display(Name = "Created at")] public readonly DateTimeOffset Created;

		[Display(Name = "Name")]
		public string FullName =>
			$"{this.GivenName} {this.FamilyName}";

		public Person(int id,
					  string givenName,
					  string familyName,
					  DateOnly dateOfBirth,
					  string email = "",
					  DateTimeOffset created = default)
		{
			this.Id = id;
			this.GivenName = givenName;
			this.FamilyName = familyName;
			this.DateOfBirth = dateOfBirth;
			this.Email = email;
			this.Created = created != default ? created : DateTimeOffset.UtcNow;
		}
	}
}
