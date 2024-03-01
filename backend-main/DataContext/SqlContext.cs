using backend_main.Interfaces;
using backend_main.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_main.DataContext
{
    public class SqlContext : DbContext, ISqlContext
    {
        public DbSet<Article> Articles { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article { Id = 1, Name = "Artikel 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ullamcorper elementum ipsum, ac tincidunt dui eleifend eget. Vestibulum gravida justo.", Price = 1.23M },
                new Article { Id = 2, Name = "Artikel 2", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ullamcorper elementum ipsum, ac tincidunt dui eleifend eget. Vestibulum gravida justo.", Price = 4.56M },
                new Article { Id = 3, Name = "Artikel 3", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ullamcorper elementum ipsum, ac tincidunt dui eleifend eget. Vestibulum gravida justo.", Price = 7.89M }
            );
        }

		public List<Article> GetArticles()
		{
			return Articles.ToList();
		}
	}
}
