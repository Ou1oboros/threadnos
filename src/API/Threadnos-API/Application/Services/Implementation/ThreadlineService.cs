using AutoMapper;
using Threadnos_API.Application.Contracts;
using Threadnos_API.Application.Exceptions;
using Threadnos_API.Application.Services.Abstraction;
using Threadnos_API.Domain.Entities;
using Threadnos_API.Domain.IRepositories;
using Threadnos_API.Domain.Services.Abstraction;
using Threadnos_API.Shared.Common;

namespace Threadnos_API.Application.Services.Implementation
{
    public class ThreadlineService : IThreadlineService
    {        
        private readonly IMapper _mapper;
        private readonly IThreadlineRepository _threadlineRepository;
        private readonly IThreadlineDomainService _threadlineDomainService;


        public ThreadlineService(IMapper mapper, IThreadlineRepository threadlineRepository, IThreadlineDomainService threadlineDomainService) 
        {            
            _mapper = mapper;
            _threadlineRepository = threadlineRepository;
            _threadlineDomainService = threadlineDomainService;
        }


        public async Task<ThreadlineDto> GetThreadlineById(Guid id)
        {
            Threadline? threadline = await _threadlineRepository.GetByIdAsync(id);

            if (threadline == null) 
                throw new NotFoundException(nameof(threadline), id);

            ThreadlineDto result = _mapper.Map<ThreadlineDto>(threadline);
            
            return result;
        }

        public async Task<PagedResult<ThreadlineDto>> GetThreadlinesByUserId(Guid id)
        {
            List<Threadline> threadlines = await _threadlineDomainService.GetThreadlinesByUserId(id);

            List<ThreadlineDto> threadlinesDto = _mapper.Map<List<ThreadlineDto>>(threadlines);

            PagedResult<ThreadlineDto> result = new PagedResult<ThreadlineDto>(threadlinesDto, threadlinesDto.Count);
            
            return result;
        }
        
        public async Task<PreviewThreadlineDto> InsertThreadline(Guid id, CreateThreadlineDto createThreadlineDto)
        {
            var threadline = _mapper.Map<Threadline>(createThreadlineDto);
            
            var response = await _threadlineRepository.InsertThreadlineAsync(id, threadline);

            if (response == null)
                throw new BadRequestException("Unable to insert threadline");
            
            PreviewThreadlineDto previewThreadlineDto = _mapper.Map<PreviewThreadlineDto>(response);
            
            return previewThreadlineDto;
        }
    }
}
