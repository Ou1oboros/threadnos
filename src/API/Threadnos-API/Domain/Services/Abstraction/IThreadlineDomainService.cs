using Threadnos_API.Domain.Entities;

namespace Threadnos_API.Domain.Services.Abstraction
{
    public interface IThreadlineDomainService
    {
        Task<List<Threadline>> GetThreadlinesByUserId(Guid id);
    }
}
