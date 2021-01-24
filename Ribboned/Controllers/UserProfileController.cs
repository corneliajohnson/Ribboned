using Microsoft.AspNetCore.Mvc;
using Ribboned.Models;
using Ribboned.Repositories;
using System.Security.Claims;

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

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var user = _userProfileRepo.GetById(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

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

        [HttpGet("{firebaseUserId}")]
        public IActionResult GetUserProfile(string firebaseUserId)
        {
            return Ok(_userProfileRepo.GetByFirebaseUserId(firebaseUserId));
        }


        // private method to get the current user.
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepo.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
