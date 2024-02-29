using System;
namespace CWNews.Models.Entities
{
	public class Category
	{
		public Category()
		{
		}

		public int Id { get; set; }
		public string Title { get; set; }

		public List<News> News { get; set; } = new();
	}
}

