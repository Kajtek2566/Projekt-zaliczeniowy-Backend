using Application.Interfaces;
using Application.Services;
using Domain.DTO;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

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
        public async Task<IEnumerable<ZooUserDTO>> Get()
        {
            return await _zooUserService.FindAll();
        }


        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string email)
        {
            ZooUserDTO zooUser;
            zooUser = await _zooUserService.FindByUserName(email);
            if (zooUser == null)
            {
                return NotFound();
            }
            return Ok(zooUser);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ZooUserDTO zooUser)
        {
            if (zooUser.UserName == null)
                return BadRequest("Missing user name");
            await _zooUserService.Add(zooUser);
            return Created();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ZooUserDTO zooUser)
        {
            _zooUserService.Update(zooUser);
            return Ok();
        }


        [HttpDelete("{userName}")]
        public IActionResult Delete(string userName)
        {
            _zooUserService.Delete(userName);
            return Ok();
        }

    }
}
