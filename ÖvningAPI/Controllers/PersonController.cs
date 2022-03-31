using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ÖvningAPI.Models;
using ÖvningAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ÖvningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository personRepo;

        public PersonController( IPersonRepository personRepository)
        {
            personRepo = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetallPersons()
        {
            return Ok(await personRepo.GetAllPerson());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            return Ok(await personRepo.GetPerson(id));
        }

        [HttpGet("interests/{id}")]
        public async Task<IActionResult> GetAllPersonsonAdressId(int id)
        {
            return Ok(await personRepo.GetAllPersonsonAdressId(id));
        }

        [HttpGet("adress/{id}")]
        public async Task<IActionResult> GetpersonwithAdress(int id)
        {
            return Ok(await personRepo.GetPersonwithAdress(id));
        }

        [HttpGet("{search}/{name}")]
        public async Task<ActionResult<IEnumerable<Person>>> Search(string name)
        {
            try
            {
                var result = await personRepo.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person persontoAdd)
        {
            try
            {
                if (persontoAdd == null)
                {
                    return BadRequest();
                }
                var createdPerson = await personRepo.Add(persontoAdd);
                return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.PersonId }, createdPerson);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add data to database");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , Person person)
        {
            try
            {
                if (id != person.PersonId)
                {
                    return BadRequest($"person with id {id} does not exist.");
                }
                var personToUpdate = await personRepo.GetPerson(id);
                if (personToUpdate == null)
                {
                    return NotFound($"Person with ID {id} was not found.");
                }
                return Ok(await personRepo.Update(person));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update to database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var personToDelete = await personRepo.GetPerson(id);
                if (personToDelete == null)
                {
                    return NotFound($"Person with id {id} was not found.");
                }
                return Ok(await personRepo.Delete(personToDelete));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete data from database.");
            }
        }
    }
}
