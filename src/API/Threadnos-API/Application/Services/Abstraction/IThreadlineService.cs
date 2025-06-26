using Threadnos_API.Application.Contracts;

namespace Threadnos_API.Application.Services.Abstraction
{
    public interface IThreadlineService
    {
        Task<ThreadlineDto> GetThreadlineById(Guid id);
        Task<PagedResult<ThreadlineDto>> GetThreadlinesByUserId(Guid id);
    }
}
