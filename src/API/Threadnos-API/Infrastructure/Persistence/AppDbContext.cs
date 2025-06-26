using Microsoft.EntityFrameworkCore;
using Threadnos_API.Domain.Entities;

namespace Threadnos_API.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Threadline> Threadline { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
