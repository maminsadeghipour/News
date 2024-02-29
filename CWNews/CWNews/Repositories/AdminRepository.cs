using System;
using CWNews.Database;
using CWNews.Models.Entities;

namespace CWNews.Repositories
{
	public class AdminRepository
	{
		private readonly AppDbContext _context = new();

		public AdminRepository()
		{
		}

		public bool IsInDatabase(Admin admin)
		{
			var isInDatabase = _context.Admins.FirstOrDefault(p => p.Username == admin.Username && p.Password == admin.Password);

			if (isInDatabase != null)
				return true;
			return false;
		}
	}
}

