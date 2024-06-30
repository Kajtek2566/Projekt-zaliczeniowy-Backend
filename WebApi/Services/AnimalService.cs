using Application.Interfaces;
using Domain.Model;
using Infrastructure.Data;
using System.Runtime.InteropServices;

namespace WebApi.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly ZooDbContext _context;

        public AnimalService(ZooDbContext context)
        {
            _context = context;
        }

        public void Add(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var animal = _context.Animals.Find(id);

            if(animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }
        }

        public List<Animal>? FindAll()
        {
            return _context.Animals.ToList();
        }

        public Animal? FindById(int id)
        {
            return _context.Animals.Find(id);
        }

        public void Update(int id, Animal animal)
        {
            var a = _context.Animals.Find(id);

            if (a != null)
            {
                a.Name = animal.Name;
                a.Species = animal.Species;

                _context.Animals.Update(a);
                _context.SaveChanges();
            }
        }
    }
}
