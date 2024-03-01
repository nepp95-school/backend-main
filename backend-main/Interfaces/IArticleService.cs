using backend_main.Models;

namespace backend_main.Interfaces
{
	public interface IArticleService
	{
		public List<Article> GetArticles();
	}
}
