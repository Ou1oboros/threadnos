using Microsoft.EntityFrameworkCore;
using Threadnos_API.Domain.Entities;

namespace PostgreSQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Threadnos_API.Domain.Entities.Thread> Threads { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
