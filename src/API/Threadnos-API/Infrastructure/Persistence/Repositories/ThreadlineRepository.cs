using Microsoft.EntityFrameworkCore;
using Threadnos_API.Domain.Entities;
using Threadnos_API.Domain.IRepositories;

namespace Threadnos_API.Infrastructure.Persistence.Repositories
{
    public class ThreadlineRepository : IThreadlineRepository
    {
        private readonly AppDbContext _context;

        public ThreadlineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Threadline?> GetByIdAsync(Guid id) {

            return await _context.FindAsync<Threadline>(id);            
        }
    }
}
