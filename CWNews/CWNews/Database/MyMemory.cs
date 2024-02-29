using System;
using CWNews.Models.Entities;

namespace CWNews.Database
{
	public static class MyMemory
	{
		public static int? ActiveJournalistId = new();

		public static bool IsAdminOnline { get; set; } 
	}
}

