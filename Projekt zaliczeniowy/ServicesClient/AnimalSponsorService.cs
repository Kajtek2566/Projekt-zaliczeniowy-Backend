using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Model;
using Newtonsoft.Json;

namespace Projekt_zaliczeniowy.ServicesClient
{
    public class AnimalSponsorService : IAnimalSponsorService
    {
        private readonly ApiService _apiService;

        public AnimalSponsorService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<AnimalSponsorDTO>> FindAllAnimalSponsorsAsync()
        {
            return await _apiService.GetAsync<IEnumerable<AnimalSponsorDTO>>("animalSponsor");
        }

        public async Task AddAsync(AnimalSponsorDTO animalSponsorDTO)
        {
            await _apiService.PostAsync<AnimalSponsorDTO>("animalSponsor", animalSponsorDTO);
        }

        public async Task UpdateAsync(AnimalSponsorDTO animalSponsorDTO)
        {
            await _apiService.PutAsync<AnimalSponsorDTO>($"animalSponsor/{animalSponsorDTO.Id}", animalSponsorDTO);
        }

        public async Task DeleteRentalAsync(int id)
        {
            await _apiService.DeleteAsync($"rentals/{id}");
        }

        public async Task DeleteAsync(int id)
        {
            await _apiService.DeleteAsync($"animalSponsor/{id}");
        }
    }
}
