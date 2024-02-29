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
    public class JournalistLoginController : Controller
    {

        private readonly JournalistService _journalistService = new();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Journalist journalist)
        {
            if (ModelState.IsValid)
            {
                var loggedin =  _journalistService.JournalistLogin(journalist);
                if (loggedin)
                    return RedirectToAction("Index", "JournalistDashboard");
                return View();

            }
            return View(journalist);
        }
        

    }
}

