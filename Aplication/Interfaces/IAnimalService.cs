using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAnimalService
    {
        void Add(Animal animal);
        void Delete(int id);
        void Update(int id, Animal animal);
        List<Animal>? FindAll();
        Animal? FindById(int id);
    }
}
