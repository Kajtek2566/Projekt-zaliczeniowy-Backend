using Application.Interfaces;
using Application.Services;
using Domain.DTO;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooUserController : ControllerBase
    {
        private IZooUserService _zooUserService;

        public ZooUserController(IZooUserService zooUserService)
        {
            _zooUserService = zooUserService;
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<IEnumerable<ZooUser>>> GetUsers()
        {
            var users = await _zooUserService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<ZooUser>> GetUser(int id)
        {
            var user = await _zooUserService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUserRole = User.FindFirstValue(ClaimTypes.Role);

            if (currentUserRole != "Admin" && currentUserId != user.ID.ToString())
            {
                return Forbid();
            }

            return Ok(user);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<ZooUser>> AddUser(ZooUser user)
        {
            await _zooUserService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] ZooUserDTO zooUserDTO)
        {
            if (id != zooUserDTO.ID)
            {
                return BadRequest();
            }

            await _zooUserService.UpdateUserAsync(zooUserDTO);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _zooUserService.DeleteUserAsync(id);
            return NoContent();
        }

    }
}
