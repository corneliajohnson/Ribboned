using Microsoft.AspNetCore.Mvc;
using Ribboned.Models;
using Ribboned.Repositories;
using System.Security.Claims;

namespace Ribboned.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RibbonController : Controller
    {
        private readonly IRibbonRepository _ribbonRepo;
        private readonly IUserProfileRepository _userRepo;
        public RibbonController(IRibbonRepository ribbonRepo, IUserProfileRepository userRepo)
        {
            _ribbonRepo = ribbonRepo;
            _userRepo = userRepo;
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
            var r = _ribbonRepo.GetById(id);
            // var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (r == null)
            {
                return NotFound();
            }

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
            //check that user exist
            var user = _ribbonRepo.GetByUserId(id);
            if (user == null)
            {
                BadRequest();
            }

            return Ok(user);
        }

        [HttpGet("mostrecentribbons/{id}")]
        public IActionResult GetMostRecentRibbons(int userId)
        {
            //check that user exist
            var user = _ribbonRepo.GetByMostRecentRibbons(userId);
            if (user == null)
            {
                BadRequest();
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var r = _ribbonRepo.GetById(id);
            //var currentUser = GetCurrentUserProfile();
            //check that ribbon exist and belongs to user
            if (r == null)
            {
                return NotFound();
            }
            _ribbonRepo.Delete(id);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search(string q)
        {
            return Ok(_ribbonRepo.Search(q, 1));
        }
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepo.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
