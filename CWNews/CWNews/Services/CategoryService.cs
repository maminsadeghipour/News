using System;
using CWNews.Models.Entities;
using CWNews.Repositories;

namespace CWNews.Services
{
	public class CategoryService
	{
		public CategoryService()
		{
		}

		private readonly CategoryRepository _repo = new();

		public List<Category> GetAll()
		{
			return _repo.GetAll();
		}

		public Category GetById(int Id)
		{
			return _repo.GetById(Id); 
		}

		public bool Delete(int Id)
		{
			return _repo.Delete(Id);
		}

		public bool Update(Category category)
		{
			return _repo.Update(category);
		}

		public bool Add(Category category)
		{
			return _repo.Add(category);
		}
	}
}

