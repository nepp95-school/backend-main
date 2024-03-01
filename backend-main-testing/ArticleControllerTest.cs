using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend_main.Controllers;
using backend_main.Interfaces;
using backend_main.Models.Responses;
using backend_main.Services;

namespace backend_main_testing
{
	internal class ArticleControllerTest
	{
		private MainController _mainController;

		[TestInitialize]
		public void Setup()
		{
			ISqlContext sqlContext = new MockSqlContext();
			IArticleService articleService = new ArticleService(sqlContext);

			_mainController = new MainController(null, articleService);
		}

		[TestMethod]
		public void GetArticles()
		{
			List<ArticleResponse> response = _mainController.GetArticles();

			Assert.IsNotNull(response);
		}
	}
}
