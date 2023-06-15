using Microsoft.EntityFrameworkCore;

namespace Movies_CRUD.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { 
            
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
