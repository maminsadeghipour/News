using System;
using System.ComponentModel.DataAnnotations;

namespace CWNews.Models.Entities
{
	public class NewsComment
	{
		public NewsComment()
		{
			AddTime = DateTime.Now;
			
		}


		public int Id { get; set; }

		[Display(Name ="کامنت")]
		[Required]
		public string Description { get; set; }

		public DateTime AddTime { get; set; }

		public int NumberOfLikes { get; set; }
		public int NumberOfDislikes { get; set; }

		public bool IsAccepteByAdmin { get; set; }
		public bool IsDeleted { get; set; }

		public int NewsId { get; set; }
		public News News { get; set; }

		public int VisitorId { get; set; }
		public Visitor Visitor { get; set; }
	}
}

