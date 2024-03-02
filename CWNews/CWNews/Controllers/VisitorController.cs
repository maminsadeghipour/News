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
    public class VisitorController : Controller
    {
        private readonly VisitorService _visitorService = new();
        private readonly NewsCommentService _newsCommentService = new();
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                var loggedin = _visitorService.IsInDatabaseAndOnline(visitor);
                if (loggedin)
                    return RedirectToAction("Index", "News");
                return View(); ;
            }
            return View(visitor);
        }

        public IActionResult VisitorComment(NewsComment comment)
        {
            
            if (MyMemory.ActiveVisitorId != null)
            {
                var added = _newsCommentService.Add(comment, (int)MyMemory.ActiveVisitorId);
                if (added)
                    return RedirectToAction("ViewNews", "News", new { Id = comment.NewsId });
                return RedirectToAction("ViewNews", "News", new { Id = comment.NewsId });
            }
            return RedirectToAction("Login");
            
        }

        public IActionResult LikeComment(int commentId)
        {
            _newsCommentService.Like(commentId);
            var newsId = _newsCommentService.GetNewsIdByCommentId(commentId);
            return RedirectToAction("ViewNews", "News", new {Id = newsId});
        }

        public IActionResult DisLikeComment(int commentId)
        {
            _newsCommentService.DisLike(commentId);
            var newsId = _newsCommentService.GetNewsIdByCommentId(commentId);
            return RedirectToAction("ViewNews", "News", new { Id = newsId });
        }


    }
}

