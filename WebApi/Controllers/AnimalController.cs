using Application.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        } 
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return _animalService.FindAll();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Animal animal;
            animal = _animalService.FindById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            if (animal.Id == null)
                return BadRequest("Missing ID");
            _animalService.Add(animal);
            return Created();
        }


        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Animal animal)
        {
            _animalService.Update(id, animal);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _animalService.Delete(id);
            return Ok();
        }
    }
}
