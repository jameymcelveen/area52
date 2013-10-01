using System;

namespace Demo.Model.Entities
{
	public class User
	{
		public Guid id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string PasswordSalt { get; set; }

	}
}

