using Application.Interfaces.Repositories;
using Domain.Model;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AnimalSponsorRepository : IAnimalSponsorRepository
    {
        private readonly ZooDbContext _contetext;
        public AnimalSponsorRepository(ZooDbContext contetext)
        {
            _contetext = contetext;
        }

        public async Task AddAsync(AnimalSponsor animalSponsor)
        {
            await _contetext.AnimalSponsors.AddAsync(animalSponsor);
            await _contetext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var a = _contetext.AnimalSponsors.Find(id);

            if (a != null) 
            {
                _contetext.AnimalSponsors.Remove(a);
                await _contetext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AnimalSponsor>> FindAllAnimalSponsorsAsync()
        {
            return await _contetext.AnimalSponsors.ToListAsync();
        }

        public async Task UpdateAsync(AnimalSponsor animalSponsor)
        {
            _contetext.AnimalSponsors.Update(animalSponsor);
            await _contetext.SaveChangesAsync();
        }
    }
}
