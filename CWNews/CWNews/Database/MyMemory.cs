using System;
using CWNews.Models.Entities;

namespace CWNews.Database
{
	public static class MyMemory
	{
		public static int? ActiveJournalistId { get; set; }

		public static int? ActiveVisitorId { get; set; } = 1;

        public static bool IsAdminOnline { get; set; } 
	}
}

