using System;
using CWNews.Models.Entities;
using CWNews.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Services
{
	public class JournalistService
	{
		public JournalistService()
		{
		}

		private readonly JournalistRepository _repo = new();


		public bool Add(Journalist journalist)
		{
			try
			{
				_repo.Add(journalist);
				return true;
			}
			catch(Exception ex) { return false; }
		}

		public bool JournalistLogin(Journalist journalist)
		{
			int journalistId = _repo.GetJournalistIdByUserPass(journalist);

			if (journalistId != 0)
			{
                Database.MyMemory.ActiveJournalistId = journalistId;
                return true;
            }
				
			return false;
		}

        public Journalist GetById(int id)
        {
			return _repo.GetById(id);
        }
    }
}

