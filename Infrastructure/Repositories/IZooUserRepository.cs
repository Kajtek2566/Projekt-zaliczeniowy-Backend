using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IZooUserRepository
    {
        Task<IEnumerable<ZooUser>> GetAllUsersAsync();
        Task<ZooUser> GetUserByIdAsync(int id);
        Task<ZooUser> GetUserByLoginAsync(string login);
        Task AddUserAsync(ZooUser user);
        Task UpdateUserAsync(ZooUser user);
        Task DeleteUserAsync(int id);
    }
}
