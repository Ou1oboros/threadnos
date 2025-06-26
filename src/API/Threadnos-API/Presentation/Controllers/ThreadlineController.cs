using Microsoft.AspNetCore.Mvc;
using Threadnos_API.Application.Contracts;
using Threadnos_API.Application.Services.Abstraction;

namespace Threadnos_API.Presentation.Controllers
{
    [ApiController]
    [Route("threadline")]
    public class ThreadlineController : ControllerBase
    {
        private readonly IThreadlineService _threadlineService;
        public ThreadlineController(IThreadlineService threadlineService)
        {

            _threadlineService = threadlineService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ThreadlineDto>> ThreadlineById(Guid id)
        {
            ThreadlineDto threadline = await _threadlineService.GetThreadlineById(id);
            
            return Ok(threadline);
        }

        [HttpGet("/users/{id}/threadlines")]
        public async Task<PagedResult<ThreadlineDto>> ThreadlinesByUserId(Guid id)
        {
            PagedResult<ThreadlineDto> threadlines = await _threadlineService.GetThreadlinesByUserId(id);

            return threadlines;
        }
    }
}
