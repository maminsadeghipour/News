using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWNews.Models.Entities;
using CWNews.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CWNews.Controllers
{
    public class JournalistRegisterController : Controller
    {
        private readonly JournalistService _journalistService = new();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Journalist jounalist)
        {
            if (ModelState.IsValid)
            {
                var registered = _journalistService.Add(jounalist);

                if (registered)
                    return RedirectToAction("Index", "JournalistLogin");

                else return View();
            }
            else return View(jounalist);
        }
    }
}

