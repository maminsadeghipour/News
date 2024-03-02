using System;
using CWNews.Database;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Repositories
{
	public class VisitorRepository
	{
		private readonly AppDbContext _context = new();

		public VisitorRepository()
		{
		}

		public Visitor? InDatabaseByUserPass(Visitor visitor)
		{
			return _context.Visitors.AsNoTracking()
				.FirstOrDefault(p => p.Username == visitor.Username && p.Password == visitor.Password);
			
		}


	}
}

