using Microsoft.EntityFrameworkCore;

namespace Mission06_Edgerton.Models
{
    public class MovieEntryContext : DbContext
    {
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base (options) 
        {
        }

        public DbSet<Application> Entries { get; set; } 
    }
}
