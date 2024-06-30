using Domain.DTO;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
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
