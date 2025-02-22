using Microsoft.EntityFrameworkCore;

namespace Joels__Movie_Website.Models
{
    public class Movie_Website_Context : DbContext
    {
        public Movie_Website_Context(DbContextOptions<Movie_Website_Context> options) : base (options) 
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Define Foreign Key Relationship
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany()
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.SetNull); // Ensures nullable behavior

            modelBuilder.Entity<Category>().HasData(
                
                new Category { CategoryId= 1, CategoryName = "Action"},
                new Category { CategoryId = 2, CategoryName =  "Romance"},
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Intrigue" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Reality" }


            );
        }
    }
}
