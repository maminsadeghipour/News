using System;
using System.ComponentModel.DataAnnotations;
using CWNews.Models.Entities;

namespace CWNews.Models.ModelViews
{
	public class NewsModelView
	{
		public NewsModelView()
		{
            AddTime = DateTime.Now;
		}

        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان الزامی می باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "توضیحات الزامی می باشد")]
        public string Description { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "عکس الزامی می باشد")]
        public IFormFile Picture { get; set; }

        public DateTime AddTime { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "دسته بندی الزامی می باشد")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public Journalist? Journalist { get; set; }

    }
}

