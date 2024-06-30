using Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt_zaliczeniowy.ServicesClient
{
    public interface IAnimalService
    {
        Task Add(AnimalDTO animalDTO);
        Task Delete(int id);
        Task Update(AnimalDTO animalDTO);
        Task<IEnumerable<AnimalDTO>> FindAll();
        Task<AnimalDTO> FindById(int id);
    }
}
