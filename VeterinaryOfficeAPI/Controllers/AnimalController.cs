using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryOfficeAPI.Entities;
using VeterinaryOfficeAPI.Models;
using VeterinaryOfficeAPI.Services;

namespace VeterinaryOfficeAPI.Controllers
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAll()
        {
            var animals = await _animalService.GetAll();

            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetById([FromRoute]int id)
        {
            var animal = await _animalService.GetById(id);

            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAnimalDto animal)
        {
            var result = await _animalService.Create(animal);

            return Created($"/api/animal/{result}", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] CreateAnimalDto dto, [FromRoute]int id)
        {
            await _animalService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            await _animalService.Delete(id);

            return NoContent();
        }
    }
}
