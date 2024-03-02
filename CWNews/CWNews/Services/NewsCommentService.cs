using System;
using CWNews.Models.Entities;
using CWNews.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Services
{
	public class NewsCommentService
	{
		private readonly NewsCommentRepository _repo = new();
        public NewsCommentService()
		{
		}

		public bool Add(NewsComment newsComment, int visitorId)
		{
			newsComment.VisitorId = visitorId;
			return _repo.Add(newsComment);
		}

		public List<NewsComment>? GetListOfUnAcceptedComment()
		{
			return _repo.GetListOfUnAcceptedComment();
		}

		public bool AcceptByAdmin(int commentId)
		{
			var comment = _repo.GetById(commentId);
			comment.IsAccepteByAdmin = true;
			_repo.Update(comment);
			return true;
		}

		public void Like(int id)
		{
			var comment = _repo.GetById(id);
			comment.NumberOfLikes++;
			_repo.Update(comment);
		}

        public void DisLike(int id)
        {
            var comment = _repo.GetById(id);
            comment.NumberOfDislikes++;
            _repo.Update(comment);
        }

        public int GetNewsIdByCommentId(int commentId)
        {
			return _repo.GetNewsIdByCommentId(commentId);
        }
    }
}

