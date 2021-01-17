using Microsoft.AspNetCore.Mvc;
using Ribboned.Models;
using Ribboned.Repositories;

namespace Ribboned.Controllers
{
    public class RibbonController : Controller
    {
        private readonly IRibbonRepository _ribbonRepo;
        public RibbonController(IRibbonRepository ribbonRepo)
        {
            _ribbonRepo = ribbonRepo;
        }

        [HttpPost]
        public IActionResult Post(Ribbon ribbon)
        {
            _ribbonRepo.Add(ribbon);
            return CreatedAtAction("Get", new { id = ribbon.Id }, ribbon);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Ribbon ribbon)
        {
            if (id != ribbon.Id)
            {
                return BadRequest();
            }

            _ribbonRepo.Update(ribbon);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _ribbonRepo.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("getbyuser/{id}")]
        public IActionResult GetByUser(int id)
        {
            return Ok(_ribbonRepo.GetByUserId(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ribbonRepo.Delete(id);
            return NoContent();
        }
    }
}
