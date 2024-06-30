using Domain.Model;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public class ZooUserRepository : IZooUserRepository
    {
        private readonly UserManager<ZooUser> _userManager;
        public ZooUserRepository(UserManager<ZooUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddAsync(ZooUser zooUser)
        {
            await _userManager.CreateAsync(zooUser);
        }

        public async Task DeleteAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }

        public async Task<IEnumerable<ZooUser>> FindAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ZooUser> FindByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task UpdateAsync(ZooUser zooUser)
        {
            var user = await _userManager.FindByNameAsync(zooUser.UserName);

            if (user != null)
            {
                
                user.FirstName = zooUser.FirstName;
                user.LastName = zooUser.LastName;
                user.UserName = zooUser.UserName;
                
                await _userManager.UpdateAsync(user);
            }
        }
    }
}
