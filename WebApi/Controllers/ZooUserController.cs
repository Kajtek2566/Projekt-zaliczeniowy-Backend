using Application.Interfaces;
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
        public IEnumerable<ZooUser> GetUsers()
        {
            return _zooUserService.FindAll();

        }

    }
}
