using lab1.DTO;
using lab1.Entity;
using lab1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace lab1.Controllers
{
    [ApiController]
    [Route("api/animal")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRep _repo;

        public AnimalController(IAnimalRep repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAnimals()
        {

            var animals = _repo.GetAll();
            return Ok(animals);
        }
        [HttpGet("{id}")]
        public IActionResult GetAnimalsByID(int id)
        {
            Animal animal = _repo.GetByID(id);
            if (animal is null)
            {
                return NotFound("Could not find animal with ID " + id);
            }
            return Ok(animal);
        }
        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] Animal animal)
        {
            Animal newAnimal = new()
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type
            };

            _repo.CreateAnimal(newAnimal);
            return CreatedAtAction(
                nameof(GetAnimals),
                new { id = newAnimal.Id },
                newAnimal);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] AnimalDTO animalDTO)
        {
            Animal existing = _repo.GetByID(id);
            if (existing == null)
            {
                return NotFound("Could not find the animal with ID " + id);
            }
            existing.Type = animalDTO.Type;
            existing.Id = id;
            existing.Name = animalDTO.Name;
            _repo.UpdateAnimal(id, animalDTO);
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            Animal existing = _repo.GetByID(id);
            if (existing == null)
            {
                return NotFound("Could not find the animal with ID " + id);
            }
            _repo.DeleteAnimal(id);
            return NoContent();
        }
    }
}
