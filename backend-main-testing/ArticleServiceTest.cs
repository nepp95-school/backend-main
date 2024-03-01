using backend_main.Interfaces;
using backend_main.Models;
using backend_main.Services;

namespace backend_main_testing
{
	[TestClass]
	public class ArticleServiceTest
	{
		private IArticleService _articleService;

		[TestInitialize]
		public void Setup()
		{
			ISqlContext sqlContext = new MockSqlContext();
			_articleService = new ArticleService(sqlContext);
		}

		[TestMethod]
		public void GetArticles()
		{
			List<Article> articles = _articleService.GetArticles();

			Assert.IsNotNull(articles);
			Assert.AreEqual(articles.Count, 3);

			for (int i = 1; i < articles.Count + 1; i++)
			{
				Article article = articles[i - 1];
				
				Assert.AreEqual(article.Id, i);
				Assert.AreEqual(article.Name, $"Artikel {i}");
				Assert.AreEqual(article.Description, "Lorem ipsum");
				Assert.AreEqual(article.Price, i);
			}
		}
	}
}