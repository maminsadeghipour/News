using System;
using CWNews.Database;
using CWNews.Models.Entities;
using CWNews.Repositories;

namespace CWNews.Services
{
	public class AdminService
	{
		private readonly AdminRepository _repo = new();

		public AdminService()
		{
		}

		public void IsInDatabase(Admin admin)
		{
			MyMemory.IsAdminOnline =  _repo.IsInDatabase(admin);
		}
	}
}

