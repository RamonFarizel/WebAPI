using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _personSerivce;

        public PersonController(IPersonService personService)
        {
            _personSerivce = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personSerivce.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personSerivce.FindByID(id);
            if (person == null)
               return NotFound();

            return Ok(person);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return new ObjectResult(_personSerivce.CreatePerson(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            return new ObjectResult(_personSerivce.Update(person));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _personSerivce.Delete(id);
            return NoContent();
        }
    }
}