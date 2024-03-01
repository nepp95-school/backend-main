using backend_main.DataContext;
using backend_main.Interfaces;
using backend_main.Models;
using System;

namespace backend_main.Services
{
    public class ArticleService : IArticleService
	{
		private ISqlContext _articleContext;

		public ArticleService(ISqlContext articleContext)
		{
			_articleContext = articleContext;
		}

		public List<Article> GetArticles()
		{
			return _articleContext.GetArticles();
		}
	}
}
