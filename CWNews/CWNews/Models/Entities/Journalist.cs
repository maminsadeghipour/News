using System;
using System.ComponentModel.DataAnnotations;

namespace CWNews.Models.Entities
{
	public class Journalist
	{
		public Journalist()
		{
		}


		public int Id { get; set; }


		[Display(Name ="نام کاربری")]
		[Required(ErrorMessage ="نام کاربری الزامی می باشد")]
		public string Username { get; set; }

		[Display(Name ="رمز عبور")]
        [Required(ErrorMessage = "رمزعبور الزامی می باشد")]
		public string Password { get; set; }

		public List<News> News { get; set; } = new();

		public bool IsDeleted { get; set; }
	}
}

