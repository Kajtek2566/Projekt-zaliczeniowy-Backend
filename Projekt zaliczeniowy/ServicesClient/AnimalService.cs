using Domain.DTO;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt_zaliczeniowy.ServicesClient
{
    public class AnimalService : IAnimalService
    {
        private readonly ApiService _apiService;

        public AnimalService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<AnimalDTO>> FindAll()
        {
            return await _apiService.GetAsync<IEnumerable<AnimalDTO>>("animal");
        }

        public async Task<AnimalDTO> FindById(int id)
        {
            return await _apiService.GetAsync<AnimalDTO>($"animal/{id}");
        }

        public async Task Add(AnimalDTO animalDTO)
        {
            await _apiService.PostAsync<AnimalDTO>("animal", animalDTO);
        }

        public async Task Update(AnimalDTO animalDTO)
        {
            await _apiService.PutAsync<AnimalDTO>($"animal/{animalDTO.Id}", animalDTO);
        }

        public async Task Delete(int id)
        {
            await _apiService.DeleteAsync($"animal/{id}");
        }
    }
}
