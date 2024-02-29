using System;
using CWNews.Models.Entities;
using CWNews.Models.ModelViews;
using CWNews.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Services
{
	public class NewsService
	{
		public NewsService()
		{
		}

		private readonly NewsRepository _repo = new();


		public List<News> GetNewsByCategoryId(int categoryId)
		{
			return _repo.GetNewsByCategoryId(categoryId);
		}

		public News GetById(int Id)
		{
			return _repo.GetById(Id);
		}

        public List<News> NewsByJournalistId(int journalistId)
        {
			return _repo.NewsByJournalistId(journalistId);
        }

		public string? AddPictureToDisk(IFormFile file)
		{
			if (file != null && file.Length > 0)
			{
				var filePathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/newsimages", file.FileName);

				var filePathForDatabase = @"/newsimages/" + file.FileName;

				using (var stream = new FileStream(filePathToSave, FileMode.Create))
				{
					file.CopyToAsync(stream);
				}

				return filePathForDatabase;
			}
			else return null;
        }

		public bool AddNews(NewsModelView newsModelView, int journalistId)
		{
			News news = new()
			{
				Title = newsModelView.Title,
				Description = newsModelView.Description,
				PicturePath = AddPictureToDisk(newsModelView.Picture),
				CategoryId = newsModelView.CategoryId,
				AddTime = newsModelView.AddTime,
				JornalistId = journalistId
			};

			_repo.Add(news);

			return true;
        }

		public NewsModelView GetNewsModelViewById(int newsId)
		{
			var news = _repo.GetById(newsId);

			NewsModelView modelView = new()
			{
				Id = news.Id,
				Title = news.Title,
				CategoryId = news.CategoryId,
				Category = news.Category,
				Journalist = news.Journalist,
				Description = news.Description,

			};

			return modelView;
		}

		public bool UpdateNews(NewsModelView newsModelView)
		{
			News news = new() { Id = newsModelView.Id,
				Title = newsModelView.Title, CategoryId = newsModelView.CategoryId,
				Description = newsModelView.Description };

			_repo.Update(news);

			return true;
		}

		public bool Delete(int newsId)
		{
			_repo.Delete(newsId);
			return true;
		}

		public void AddView(int newsId)
		{
			var news = _repo.GetById(newsId);
			news.NumberOfViews++;
			_repo.Update(news);
		}

		public List<News> GetUnAcceptedNews()
		{
			return _repo.GetUnAcceptedNews();
		}

		public bool AcceptNewsByAdmin(int newsId)
		{
			var news = _repo.GetById(newsId);

			news.IsAcceptedByAdmin = true;

			_repo.Update(news);

			return true;
		}
    }
}

