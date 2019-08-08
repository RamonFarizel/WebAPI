using Microsoft.AspNetCore.Mvc;
using WebAPI.Business;
using WebAPI.Data.VO;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null)
               return NotFound();

            return Ok(person);
        }


        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            return new ObjectResult(_personBusiness.CreatePerson(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            var updatedPerson = _personBusiness.Update(person);
            if (updatedPerson == null)
                return NoContent();

            return new ObjectResult(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}