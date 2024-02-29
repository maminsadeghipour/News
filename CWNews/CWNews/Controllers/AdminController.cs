using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWNews.Database;
using CWNews.Models.Entities;
using CWNews.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CWNews.Controllers
{
    public class AdminController : Controller
    {

        private readonly AdminService _adminService = new();
        private readonly CategoryService _categoryService = new();
        private readonly NewsService _newsService = new();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin admin)
        {
            _adminService.IsInDatabase(admin);
            if (MyMemory.IsAdminOnline)
                return RedirectToAction("AdminDashboard");
            else
                return RedirectToAction("Index");
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult CategoriesManagement()
        {
            if (MyMemory.IsAdminOnline)
            {
                var categories = _categoryService.GetAll();
                return View(categories);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int Id)
        {
            if (MyMemory.IsAdminOnline)
            {
                _categoryService.Delete(Id);
                return RedirectToAction("CategoriesManagement"); 
            }
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCategory(int Id)
        {
            if (MyMemory.IsAdminOnline)
            {
                var category = _categoryService.GetById(Id);
                return View(category);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (MyMemory.IsAdminOnline)
            {
                var updated = _categoryService.Update(category);
                if (updated)
                    return RedirectToAction("CategoriesManagement");
                else
                    return View(category);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddCategory()
        {
            if (MyMemory.IsAdminOnline)
                return View();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (MyMemory.IsAdminOnline)
            {
                var added = _categoryService.Add(category);
                if (added)
                    return RedirectToAction("CategoriesManagement");
                else
                    return View(category);
            }
            return RedirectToAction("Index");
        }

        public IActionResult GetListOfUnacceptedNews()
        {
            if (MyMemory.IsAdminOnline)
            {
                var news = _newsService.GetUnAcceptedNews();
                return View(news);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AcceptNews(int Id)
        {
            if (MyMemory.IsAdminOnline)
            {
                var accepted = _newsService.AcceptNewsByAdmin(Id);
                if (accepted)
                    return RedirectToAction("AdminDashboard");
                return RedirectToAction("GetListOfUnacceptedNews");
            }
            return RedirectToAction("Index");
        }
    }
    
}

