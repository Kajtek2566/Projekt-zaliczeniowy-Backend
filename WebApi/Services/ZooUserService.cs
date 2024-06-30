using Application.Interfaces;
using Domain.Model;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Services
{
    public class ZooUserService : IZooUserService
    {
        private readonly UserManager<ZooUser> _userManager;

        public ZooUserService(UserManager<ZooUser> userManager)
        {
            _userManager = userManager;
        }

        public List<ZooUser> FindAll()
        {
            return _userManager.Users.Select(u => u).ToList();
        }
    }
}
