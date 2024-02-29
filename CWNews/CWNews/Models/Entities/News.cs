using System;
namespace CWNews.Models.Entities
{
	public class News
	{
		public News()
		{
		}

		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string PicturePath { get; set; }
		public DateTime AddTime { get; set; }

		public int JornalistId { get; set; }
		public Journalist Journalist { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public bool IsDeleted { get; set; }

		public bool IsAcceptedByAdmin { get; set; }

		public int NumberOfViews { get; set; }

	}
}

