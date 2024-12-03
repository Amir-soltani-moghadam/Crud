using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        
            private readonly AppDbContext _context;

            public PersonController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var people = await _context.People.ToListAsync();
                return Ok(people);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var person = await _context.People.FindAsync(id);
                if (person == null)
                    return NotFound();

                return Ok(person);
            }

            [HttpPost]
            public async Task<IActionResult> Create(Person person)
            {
                _context.People.Add(person);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Person updatedPerson)
            {
                if (id != updatedPerson.Id)
                    return BadRequest();

                var person = await _context.People.FindAsync(id);
                if (person == null)
                    return NotFound();

                person.Name = updatedPerson.Name;
                person.Lastname = updatedPerson.Lastname;
                person.NationalCode = updatedPerson.NationalCode;
                person.BirthDate = updatedPerson.BirthDate;

                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var person = await _context.People.FindAsync(id);
                if (person == null)
                    return NotFound();

                _context.People.Remove(person);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        
    }
}
