using Domain.Model;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ZooDbContext _contetext;
        public AnimalRepository(ZooDbContext contetext)
        {
            _contetext = contetext;
        }

        public async Task AddAsync(Animal animal)
        {
            _contetext.Animals.Add(animal);
            await _contetext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var animal = await _contetext.Animals.FindAsync(id);
            if(animal != null)
            {
                _contetext.Animals.Remove(animal);
                await _contetext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Animal>> FindAllAsync()
        {
            return await _contetext.Animals.ToListAsync();
        }

        public async Task<Animal> FindByIdAsync(int id)
        {
            return await _contetext.Animals.FindAsync(id);
        }

        public async Task UpdateAsync(Animal animal)
        {
            _contetext.Animals.Update(animal);
            await _contetext.SaveChangesAsync();
        }
    }
}
