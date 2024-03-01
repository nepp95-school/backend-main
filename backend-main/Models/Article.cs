using System.ComponentModel.DataAnnotations;

namespace backend_main.Models
{
	public class Article
	{
		[Key]
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string? Description { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}
