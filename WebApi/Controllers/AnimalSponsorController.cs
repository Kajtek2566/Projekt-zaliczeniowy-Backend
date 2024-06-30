using Application.Services;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalSponsorController : ControllerBase
    {
        private IAnimalSponsorService _animalSponsorService;

        public AnimalSponsorController(IAnimalSponsorService animalSponsorService)
        {
            _animalSponsorService = animalSponsorService;
        }

        [HttpGet]
        public async Task<IEnumerable<AnimalSponsorDTO>> Get()
        {
            return await _animalSponsorService.FindAllAnimalSponsorsAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimalSponsorDTO animalSponsor)
        {
            if (animalSponsor.Id == null)
                return BadRequest("Missing ID");
            await _animalSponsorService.AddAsync(animalSponsor);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimalSponsorDTO animalSponsor)
        {
            await _animalSponsorService.UpdateAsync(animalSponsor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _animalSponsorService.DeleteAsync(id);
            return Ok();
        }
    }
}
