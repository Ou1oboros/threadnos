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

            return await _context.Threadline
                .AsNoTracking()                
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Threadline>?> GetByUserIdAsync(Guid id) {

            User? user = await _context.Users
                .AsNoTracking()
                .Include(u => u.Threadlines)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return null;

            List<Threadline> threadlines = user.Threadlines ?? new List<Threadline>();

            return threadlines;
        }
    }
}
