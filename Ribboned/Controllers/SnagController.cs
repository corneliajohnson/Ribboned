using Microsoft.AspNetCore.Mvc;
using Ribboned.Models;
using Ribboned.Repositories;
using System;

namespace Ribboned.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnagController : ControllerBase
    {
        private readonly ISnagRepository _snagRepo;
        public SnagController(ISnagRepository snagRepo)
        {
            _snagRepo = snagRepo;
        }

        [HttpGet("getbyribbon/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_snagRepo.GetByRibbon(id));
        }

        [HttpPost]
        public IActionResult Post(Snag snag)
        {
            snag.DateCreated = DateTime.Now;
            _snagRepo.Add(snag);
            return CreatedAtAction("Get", new { id = snag.Id }, snag);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Snag snag)
        {
            if (id != snag.Id)
            {
                return BadRequest();
            }
            snag.DateCreated = DateTime.Now;
            _snagRepo.Update(snag);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _snagRepo.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _snagRepo.Delete(id);
            return NoContent();
        }
    }
}
