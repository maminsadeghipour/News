using System;
using CWNews.Database;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Repositories
{
	public class JournalistRepository
	{

		public JournalistRepository()
		{
		}

		private readonly AppDbContext _context = new();

		public bool Add(Journalist journalist)
		{
			_context.Journalists.Add(journalist);
			_context.SaveChanges();
			return true;
		}

		public int GetJournalistIdByUserPass(Journalist journalist)
		{
			//var result = _context.Journalists.Select(p=> new {p.Id, p.Username,p.Password}).FirstOrDefault(p => p.Username == journalist.Username && p.Password == journalist.Password);
			//if (result != null)
			//	return result.Id;
			//return null;

			int result = _context.Journalists.Where(p => p.Username == journalist.Username && p.Password == journalist.Password).Select(p => p.Id).FirstOrDefault();
			return result;
		}

		public Journalist GetById(int id)
		{
			var q = _context.Journalists.Where(p => p.Id == id).Include(p => p.News.Where(n=> !n.IsDeleted));

			var qs = q.ToQueryString();

			return q.FirstOrDefault();
		}
	}
}

