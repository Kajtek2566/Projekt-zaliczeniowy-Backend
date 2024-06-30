using Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt_zaliczeniowy.ServicesClient
{
    public interface IAnimalSponsorService
    {
        Task<IEnumerable<AnimalSponsorDTO>> FindAllAnimalSponsorsAsync();
        Task AddAsync(AnimalSponsorDTO animalSponsorDTO);
        Task DeleteAsync(int id);
        Task UpdateAsync(AnimalSponsorDTO animalSponsorDTO);
    }
}
