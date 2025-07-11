using Microsoft.EntityFrameworkCore;
using Threadnos_API.Domain.Entities;
using Threadnos_API.Shared.Common;

namespace Threadnos_API.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly RequestContext _requestContext;
        public DbSet<Threadline> Threadline { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<User> Users { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options, RequestContext requestContext)
            : base(options)
        {
            _requestContext = requestContext;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            DateTime now = DateTime.Now;
            string username = _requestContext.CurrentUsername ?? "system";

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                    entry.Entity.CreatedBy = username;
                    entry.Entity.UpdatedBy = username;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                    entry.Entity.UpdatedBy = username;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        
    }
}
