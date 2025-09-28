using Microsoft.AspNetCore.Mvc;
using PersonCRUD.Application.Commands.CreatePersonCommand;
using PersonCRUD.Application.DTOs;

namespace PersonCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet(Name = "GetPerson")]
        public IEnumerable<object> Get()
        {   
            throw new NotImplementedException();
        }

        [HttpPost(Name = "CreatePerson")]
        public IActionResult Post([FromBody] CreatePersonCommand command)
        {
            PersonDTO dto = CreatePersonHandler.Handle(command);
            return Ok(dto);
        }

        [HttpPut(Name = "UpdatePerson")]
        public IEnumerable<object> Put()
        {
            throw new NotImplementedException();
        }

        [HttpDelete(Name = "DeletePerson")]
        public IEnumerable<object> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
