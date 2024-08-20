using Microsoft.EntityFrameworkCore;

namespace Pingis.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions
             options) : base(options)
        {
        }

        public DbSet<TableTennisSet> Sets { get; set; }
    }

}
