using Microsoft.EntityFrameworkCore;

namespace CodeFirstWeb.Data
{
    public class ShowManagerContext : DbContext
    {
        public ShowManagerContext(DbContextOptions<ShowManagerContext> options)
                    : base(options)
        {
        }

        public DbSet<Episode> Episodes { get; set; }

        public DbSet<Show> Posts { get; set; }
    }
}