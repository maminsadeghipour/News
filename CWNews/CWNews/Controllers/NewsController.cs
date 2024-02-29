using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWNews.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CWNews.Controllers
{
    public class NewsController : Controller
    {

        private readonly CategoryService _categoryService = new();
        private readonly NewsService _newsService = new();

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult VeiwNewsByCategory(int Id)
        {
            var news = _newsService.GetNewsByCategoryId(Id);
            return View(news);
        }

        public IActionResult ViewNews(int Id)
        {
            var news = _newsService.GetById(Id);
            _newsService.AddView(Id);
            return View(news);
        }
    }
}

