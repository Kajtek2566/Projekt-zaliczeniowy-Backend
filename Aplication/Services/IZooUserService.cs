using Domain.DTO;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IZooUserService
    {
        Task<IEnumerable<ZooUserDTO>> GetAllUsersAsync();
        Task<ZooUserDTO> GetUserByIdAsync(int id);
        Task<ZooUser> GetUserByLoginAsync(string login);
        Task AddUserAsync(ZooUser zooUser);
        Task UpdateUserAsync(ZooUserDTO zooUserDTO);
        Task DeleteUserAsync(int id);
        Task RegisterUserAsync(RegisterDTO registerDTO);
    }
}
