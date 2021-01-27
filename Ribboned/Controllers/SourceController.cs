using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ribboned.Repositories;

namespace Ribboned.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SourceController : ControllerBase
    {
        private readonly ISourceRepository _sourceRepo;
         public SourceController(ISourceRepository sourceRepo)
        {
            _sourceRepo = sourceRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sourceRepo.GetAll());
        }
    }
}
