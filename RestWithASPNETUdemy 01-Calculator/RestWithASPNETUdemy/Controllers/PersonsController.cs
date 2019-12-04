using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Implementation;
namespace RestWithASPNETUdemy.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase {

        private IPersonService _personService;

        // usado _ para dizer q pertence a msm classe sendo assim não usa o this

        public PersonsController(IPersonService personService) {
            _personService = personService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get() {
            return Ok(_personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {

            var person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person person) {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person) {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _personService.Delete(id);
            return NoContent();


        }
    }
}
