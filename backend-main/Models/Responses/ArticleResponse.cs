using Newtonsoft.Json.Linq;

namespace backend_main.Models.Responses
{
	public class ArticleResponse
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }

		public ArticleResponse()
		{}

		public ArticleResponse(long id, string name, string? description, decimal price)
		{
			Id = id;
			Name = name;
			Description = description;
			Price = price;
		}
	}
}
