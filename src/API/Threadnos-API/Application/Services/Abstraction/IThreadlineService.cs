using Threadnos_API.Application.Contracts;
using Threadnos_API.Shared.Common;

namespace Threadnos_API.Application.Services.Abstraction
{
    public interface IThreadlineService
    {
        Task<ThreadlineDto> GetThreadlineById(Guid id);
        Task<PagedResult<ThreadlineDto>> GetThreadlinesByUserId(Guid id);
        
        Task<PreviewThreadlineDto> InsertThreadline(Guid id, CreateThreadlineDto threadline);
    }
}
