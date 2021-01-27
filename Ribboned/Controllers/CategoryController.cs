using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ribboned.Models;
using Ribboned.Repositories;
using System.Security.Claims;

namespace Ribboned.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController :ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IUserProfileRepository _userRepo;
        public CategoryController(ICategoryRepository categoryRepo, IUserProfileRepository userRepo)
        {
            _categoryRepo = categoryRepo;
            _userRepo = userRepo;
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
            var currentUser = GetCurrentUserProfile();
            var category = _categoryRepo.GetById(id);
            if (category == null || category.UserProfileId != currentUser.Id)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepo.GetById(id);
            var currentUser = GetCurrentUserProfile();
            //check that category exist and belongs to user
            if (category == null || category.UserProfileId != currentUser.Id)
            {
                return NotFound();
            }

            if(category.Name == "Other")
            {
                return BadRequest();
            }

            _categoryRepo.Delete(id, currentUser.Id);
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
             var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (c == null || c.UserProfileId != currentUser.Id)
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

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepo.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
