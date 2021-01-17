using Microsoft.AspNetCore.Mvc;
using Ribboned.Models;
using Ribboned.Repositories;

namespace Ribboned.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepo;
        public UserProfileController(IUserProfileRepository userProfileRepo)
        {
            _userProfileRepo = userProfileRepo;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _userProfileRepo.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post(UserProfile up)
        {
            _userProfileRepo.Add(up);
            return CreatedAtAction("Get", new { id = up.Id }, up);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile up)
        {
            if (id != up.Id)
            {
                return BadRequest();
            }

            _userProfileRepo.Update(up);
            return NoContent();
        }
    }
}
