using Application.Interfaces;
using Application.Services;
using Domain.DTO;
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
        public async Task<IEnumerable<AnimalDTO>> Get()
        {
            return await _animalService.FindAll();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            AnimalDTO animal;
            animal = await _animalService.FindById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimalDTO animal)
        {
            if (animal.Id == null)
                return BadRequest("Missing ID");
            _animalService.Add(animal);
            return Created();
        }

        [HttpPut]
        public IActionResult Put([FromBody] AnimalDTO animal)
        {
            _animalService.Update(animal);
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
