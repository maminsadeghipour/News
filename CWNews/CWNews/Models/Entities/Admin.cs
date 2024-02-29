using System;
namespace CWNews.Models.Entities
{
	public class Admin
	{
		public Admin()
		{
		}

		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}
}

