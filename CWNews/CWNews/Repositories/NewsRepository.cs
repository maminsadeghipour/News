using System;
using CWNews.Database;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Repositories
{
	public class NewsRepository
	{
		public NewsRepository()
		{
		}

		private readonly AppDbContext _context = new();


		public List<News> GetNewsByCategoryId(int categoryId)
		{
			var query = _context.News.Include(p => p.Journalist).Where(p => p.CategoryId == categoryId && !p.IsDeleted && p.IsAcceptedByAdmin);

			var q = query.ToQueryString();

            return query.ToList();
		}

		public News? GetById(int Id)
		{
			return _context.News.Include(p => p.Journalist)
				.Include(p=>p.Category)
				.Include(p=>p.Comments.Where(c=>c.IsAccepteByAdmin)).ThenInclude(c=>c.Visitor)
				.FirstOrDefault(p => p.Id == Id);
		}

		public List<News> NewsByJournalistId(int journalistId)
		{
			return _context.News.Where(p => p.JornalistId == journalistId && !p.IsDeleted).ToList();
		}

		public bool Add(News news)
		{
			_context.News.Add(news);
			_context.SaveChanges();
			return true;
		}

		public bool Update(News news)
		{
			var newsToUpdate = _context.News.FirstOrDefault(p=>p.Id == news.Id);

			newsToUpdate.Title = news.Title;
			newsToUpdate.Description = news.Description;
			newsToUpdate.CategoryId = news.CategoryId;

			_context.SaveChanges();

			return true;
		}

		public bool Delete(int newsId)
		{
			var newsToDelete = _context.News.Find(newsId);

			//newsToDelete.IsDeleted = true;

			_context.News.Remove(newsToDelete);

			_context.SaveChanges();

			return true;
		}

		public List<News> GetUnAcceptedNews()
		{
			return _context.News.Include(p=>p.Journalist).Where(p => !p.IsAcceptedByAdmin).ToList();
		}

		
	}
}

