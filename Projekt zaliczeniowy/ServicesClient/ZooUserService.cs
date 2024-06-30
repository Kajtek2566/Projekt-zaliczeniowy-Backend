using Domain.DTO;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt_zaliczeniowy.ServicesClient
{
    public class ZooUserService
    {
        private readonly ApiService _apiService;

        public ZooUserService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<ZooUser>> GetAllUsersAsync()

        {
            return await _apiService.GetAsync<List<ZooUser>>("zooUser");
        }

        public async Task<ZooUserDTO> GetUserByIdAsync(int id)
        {
            return await _apiService.GetAsync<ZooUserDTO>($"zooUser/{id}");
        }

        public async Task<bool> CreateUserAsync(ZooUser zooUser)
        {
            var createdUser = await _apiService.PostAsync<ZooUser>("zooUser", zooUser);
            return createdUser != null;
        }

        public async Task<bool> UpdateUserAsync(ZooUserDTO zooUserDTO)
        {
            var updatedUser = await _apiService.PutAsync<ZooUserDTO>($"zooUser/{zooUserDTO.ID}", zooUserDTO);
            return updatedUser != null;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await _apiService.DeleteAsync($"zooUser/{id}");
            return true;
        }
    }
}
