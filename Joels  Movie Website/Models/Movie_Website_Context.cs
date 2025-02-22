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

    }
}
