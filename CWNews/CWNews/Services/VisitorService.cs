using System;
using CWNews.Database;
using CWNews.Models.Entities;
using CWNews.Repositories;

namespace CWNews.Services
{
	public class VisitorService
	{
		private readonly VisitorRepository _repo = new();

		public VisitorService()
		{
		}

		public bool IsInDatabaseAndOnline(Visitor visitor)
		{
			Visitor? visitorInDatabse = _repo.InDatabaseByUserPass(visitor);
			if (visitorInDatabse != null)
			{
				MyMemory.ActiveVisitorId = visitorInDatabse.Id;
				return true;
			}
			return false;
		}
	}
}

