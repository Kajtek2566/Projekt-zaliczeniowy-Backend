using Domain.DTO;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAnimalSponsorService
    {
        Task<IEnumerable<AnimalSponsorDTO>> FindAllAnimalSponsorsAsync();
        Task AddAsync(AnimalSponsorDTO animalSponsorDTO);
        Task DeleteAsync(int id);
        Task UpdateAsync(AnimalSponsorDTO animalSponsorDTO);
    }
}
