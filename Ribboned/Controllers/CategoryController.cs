using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ribboned.Models;
using Ribboned.Repositories;

namespace Ribboned.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController :ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryRepo.GetAll());
        }

        [HttpGet("getbyuserid/{id}")]
        public IActionResult GetByUserId(int id)
        {
            return Ok(_categoryRepo.GetByUserId(id));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _categoryRepo.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var c = _categoryRepo.GetById(id);
            //var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (c == null)
            {
                return NotFound();
            }
            _categoryRepo.Delete(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult Post(Category category)
        {
            _categoryRepo.Add(category);
            return CreatedAtAction("Get", new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category)
        {
            var c = _categoryRepo.GetById(id);
            // var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (c == null)
            {
                return NotFound();
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            _categoryRepo.Update(category);
            return NoContent();
        }
    }
}
