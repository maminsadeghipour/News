using System;
using CWNews.Database;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Repositories
{
	public class CategoryRepository
	{
		public CategoryRepository()
		{
		}

		private readonly AppDbContext _context = new();

		public List<Category> GetAll()
		{
			//return _context.Categories.ToList();
			//_context.Categories.Include(p => p.News).GroupBy(p => p.News)

			return _context.Categories.Include(p => p.News).ToList();
		}

		public Category GetById(int Id)
		{
			return _context.Categories.Find(Id);
		}

		public bool Delete(int Id)
		{
			var category = _context.Categories.Find(Id);
			_context.Categories.Remove(category);
			_context.SaveChanges();
			return true;
		}

		public bool Update(Category category)
		{
			var catToUpdate = _context.Categories.Find(category.Id);
			catToUpdate.Title = category.Title;
			_context.SaveChanges();
			return true;
		}

		public bool Add(Category category)
		{
			_context.Add(category);
			_context.SaveChanges();
			return true;
		}
	}
}

