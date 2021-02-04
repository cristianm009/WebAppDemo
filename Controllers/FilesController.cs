using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebAppDemos.Application.Commands;
using WebAppDemos.Application.Queries;

namespace WebAppDemos.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public FilesController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllFilesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{dni}")]
        public async Task<IActionResult> GetByRequestId(string requestId)
        {
            var query = new GetFileByRequestIdQuery(requestId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}
