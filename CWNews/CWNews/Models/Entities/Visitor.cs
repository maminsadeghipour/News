using System;
namespace CWNews.Models.Entities
{
	public class Visitor
	{
		public Visitor()
		{
		}


		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public List<NewsComment> NewsComments { get; set; }
	}
}

