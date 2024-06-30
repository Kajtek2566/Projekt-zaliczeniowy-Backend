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
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task Add(AnimalDTO animalDTO)
        {
            var animal = _mapper.Map<Animal>(animalDTO);
            await _animalRepository.AddAsync(animal);
        }

        public async Task Delete(int id)
        {
            await _animalRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AnimalDTO>> FindAll()
        {
            var animals = await _animalRepository.FindAllAsync();
            return _mapper.Map<IEnumerable<AnimalDTO>>(animals);
        }

        public async Task<AnimalDTO> FindById(int id)
        {
            var animal = await _animalRepository.FindByIdAsync(id);
            return _mapper.Map<AnimalDTO>(animal);
        }

        public async Task Update(AnimalDTO animalDTO)
        {
            var animal = _mapper.Map<Animal>(animalDTO);
            await _animalRepository.UpdateAsync(animal);
        }
    }
}
