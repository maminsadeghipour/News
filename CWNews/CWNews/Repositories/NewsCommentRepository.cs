using System;
using CWNews.Database;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Repositories
{
	public class NewsCommentRepository
	{
		private readonly AppDbContext _context = new();

		public NewsCommentRepository()
		{
		}

		public bool Add(NewsComment newsComment)
		{
			_context.NewsComments.Add(newsComment);
			_context.SaveChanges();
			return true;
		}

        public List<NewsComment>? GetListOfUnAcceptedComment()
        {
			return _context.NewsComments.Include(c=>c.Visitor).Where(c => !c.IsAccepteByAdmin).ToList();

        }

		public NewsComment GetById(int id)
		{
			return _context.NewsComments.AsTracking().FirstOrDefault(c => c.Id == id);
		}

		public bool Update(NewsComment newsComment)
		{
			var commentInDatabase = _context.NewsComments.AsNoTracking().FirstOrDefault(c => c.Id == newsComment.Id);

			commentInDatabase.IsAccepteByAdmin = newsComment.IsAccepteByAdmin;
			commentInDatabase.NumberOfLikes = newsComment.NumberOfLikes;
			commentInDatabase.NumberOfDislikes = newsComment.NumberOfDislikes;

			_context.SaveChanges();

			return true;
		}

		public int GetNewsIdByCommentId(int commentId)
		{
			return _context.NewsComments.Where(p => p.Id == commentId).Select(p => p.NewsId).FirstOrDefault();
		}

		
    }
}

