using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IAnimalRepository
    {
        Task AddAsync (Animal animal);
        Task DeleteAsync(int id);
        Task UpdateAsync( Animal animal);
        Task<IEnumerable<Animal>> FindAllAsync();
        Task<Animal> FindByIdAsync(int id);
    }
}
