using backend_main.Interfaces;
using backend_main.Models;

namespace backend_main_testing
{
	internal class MockSqlContext : ISqlContext
	{
		private List<Article> _articles = new List<Article>();

		public MockSqlContext()
		{
			_articles = new List<Article>();
			_articles.Add(new Article() { Id = 1, Name = "Artikel 1", Description = "Lorem ipsum", Price = 1.00M });
			_articles.Add(new Article() { Id = 2, Name = "Artikel 2", Description = "Lorem ipsum", Price = 2.00M });
			_articles.Add(new Article() { Id = 3, Name = "Artikel 3", Description = "Lorem ipsum", Price = 3.00M });
		}

		public List<Article> GetArticles()
		{
			return _articles;
		}
	}
}
