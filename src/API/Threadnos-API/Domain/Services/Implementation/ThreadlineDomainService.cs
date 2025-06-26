using Threadnos_API.Domain.Entities;
using Threadnos_API.Domain.Exceptions;
using Threadnos_API.Domain.IRepositories;
using Threadnos_API.Domain.Services.Abstraction;

namespace Threadnos_API.Domain.Services.Implementation
{
    public class ThreadlineDomainService : IThreadlineDomainService
    {
        private readonly IThreadlineRepository _repository;
        
        public ThreadlineDomainService(IThreadlineRepository threadlineRepository) 
        {
            _repository = threadlineRepository;
        }

        public async Task<List<Threadline>> GetThreadlinesByUserId(Guid id)
        {
            List<Threadline>? threadlines = await _repository.GetByUserIdAsync(id);

            if (threadlines == null)
                throw new BusinessException("no user exists with such id");

            return threadlines;
        }
    }
}
