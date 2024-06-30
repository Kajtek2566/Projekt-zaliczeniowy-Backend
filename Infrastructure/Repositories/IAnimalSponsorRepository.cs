using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IAnimalSponsorRepository
    {
        Task<IEnumerable<AnimalSponsor>> FindAllAnimalSponsorsAsync();
        Task AddAsync(AnimalSponsor animalSponsor);
        Task DeleteAsync(int id);
        Task UpdateAsync(AnimalSponsor animalSponsor);
    }
}
