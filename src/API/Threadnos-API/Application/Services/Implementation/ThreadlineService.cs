using AutoMapper;
using Threadnos_API.Application.Contracts;
using Threadnos_API.Application.Exceptions;
using Threadnos_API.Application.Services.Abstraction;
using Threadnos_API.Domain.Entities;
using Threadnos_API.Domain.IRepositories;

namespace Threadnos_API.Application.Services.Implementation
{
    public class ThreadlineService : IThreadlineService
    {        
        private readonly IMapper _mapper;
        private readonly IThreadlineRepository _threadlineRepository;
        public ThreadlineService(IMapper mapper, IThreadlineRepository threadlineRepository) 
        {            
            _mapper = mapper;
            _threadlineRepository = threadlineRepository;
        }
        public async Task<ThreadlineDto> GetThreadlineById(Guid id)
        {
            Threadline? threadline = await _threadlineRepository.GetByIdAsync(id);

            if (threadline == null) 
                throw new NotFoundException(nameof(threadline), id);

            ThreadlineDto result = _mapper.Map<ThreadlineDto>(threadline);
            
            return result;
        }
    }
}
