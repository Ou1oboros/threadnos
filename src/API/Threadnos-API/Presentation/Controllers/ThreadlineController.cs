using Microsoft.AspNetCore.Mvc;
using Threadnos_API.Application.Contracts;
using Threadnos_API.Application.Services.Abstraction;

namespace Threadnos_API.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThreadlineController : ControllerBase
    {
        private readonly IThreadlineService _threadlineService;
        public ThreadlineController(IThreadlineService threadlineService)
        {

            _threadlineService = threadlineService;
        }
        [HttpGet]
        public async Task<ThreadlineDto> ThreadlineById(Guid id)
        {
            return await _threadlineService.GetThreadlineById(id);
        }
    }
}
