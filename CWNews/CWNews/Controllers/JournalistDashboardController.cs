using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWNews.Database;
using CWNews.Models.ModelViews;
using CWNews.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CWNews.Controllers
{
    public class JournalistDashboardController : Controller
    {
        private readonly JournalistService _journalistService = new();
        private readonly NewsService _newsService = new();
        private readonly CategoryService _categoryService = new();
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            if(MyMemory.ActiveJournalistId != null)
            {
                var Journalist = _journalistService.GetById((int)MyMemory.ActiveJournalistId);
                return View(Journalist);
            }
            return RedirectToAction("Index", "JournalistLogin");
        }

        public IActionResult JournalistNews()
        {
            if (MyMemory.ActiveJournalistId != null)
            {
                var news = _newsService.NewsByJournalistId((int)MyMemory.ActiveJournalistId);
                return View(news);
            }
            return RedirectToAction("Index", "JournalistLogin");
        }


        public IActionResult AddNews()
        {
            if (MyMemory.ActiveJournalistId != null)
            {
                ViewBag.Categories = _categoryService.GetAll();
                return View();
            }
            return RedirectToAction("Index", "JournalistLogin");
        }

        [HttpPost]
        public IActionResult AddNews(NewsModelView newsModelView)
        {        
             if (MyMemory.ActiveJournalistId != null)
             {
                 if (ModelState.IsValid)
                 {
                     var newsAdded = _newsService.AddNews(newsModelView,(int)MyMemory.ActiveJournalistId);

                     if (newsAdded) return RedirectToAction("Index");
                     return View();
                 }
                 ViewBag.Categories = _categoryService.GetAll();
                 return View(newsModelView);         
             }
             return RedirectToAction("Index", "JournalistLogin");
        }


        public IActionResult UpdateNews(int NewsId)
        {
            var newsModelView = _newsService.GetNewsModelViewById(NewsId);
            ViewBag.Categories = _categoryService.GetAll();
            return View(newsModelView);
        }

        [HttpPost]
        public IActionResult UpdateNews(NewsModelView newsModelView)
        {
            var updated = _newsService.UpdateNews(newsModelView);
            if (updated)
                return RedirectToAction("Index");

            return View(newsModelView);
        }

        public IActionResult DeleteNews(int NewsId)
        {
            if(MyMemory.ActiveJournalistId != null)
            {
                var deleted = _newsService.Delete(NewsId);
                if (deleted)
                    return RedirectToAction("Index");
                return View();
            }
            return RedirectToAction("Index", "JournalistLogin");
        }
    }
}

