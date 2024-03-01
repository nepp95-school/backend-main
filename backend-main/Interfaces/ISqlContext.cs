using backend_main.Models;

namespace backend_main.Interfaces
{
	public interface ISqlContext
	{
		List<Article> GetArticles();
	}
}
