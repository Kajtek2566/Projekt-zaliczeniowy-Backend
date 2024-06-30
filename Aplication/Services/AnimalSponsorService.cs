using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.DTO;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AnimalSponsorService : IAnimalSponsorService
    {
        private readonly IAnimalSponsorRepository _animalSponsorRepository;
        private readonly IMapper _mapper;

        public AnimalSponsorService(IAnimalSponsorRepository animalSponsorRepository, IMapper mapper)
        {
            _animalSponsorRepository = animalSponsorRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AnimalSponsorDTO animalSponsorDTO)
        {
            var animalSponsor = _mapper.Map<AnimalSponsor>(animalSponsorDTO);
            await _animalSponsorRepository.AddAsync(animalSponsor);
        }

        public async Task DeleteAsync(int id)
        {
            await _animalSponsorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AnimalSponsorDTO>> FindAllAnimalSponsorsAsync()
        {
            var animalSponsors = await _animalSponsorRepository.FindAllAnimalSponsorsAsync();
            return _mapper.Map < IEnumerable<AnimalSponsorDTO>>(animalSponsors);
        }

        public async Task UpdateAsync(AnimalSponsorDTO animalSponsorDTO)
        {
            var animalSponsor = _mapper.Map<AnimalSponsor>(animalSponsorDTO);
            await _animalSponsorRepository.UpdateAsync(animalSponsor);
        }
    }
}
