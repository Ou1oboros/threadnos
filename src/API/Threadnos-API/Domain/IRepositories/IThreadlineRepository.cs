using Microsoft.EntityFrameworkCore;
using Threadnos_API.Domain.Entities;

namespace Threadnos_API.Domain.IRepositories
{
    public interface IThreadlineRepository
    {
        Task<Threadline?> GetByIdAsync(Guid id);         
            
    }
}
