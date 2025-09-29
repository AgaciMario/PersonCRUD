using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonCRUD.Application.Commands.CreatePersonCommand;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Server.Records;

namespace PersonCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PersonController : ControllerBase
    {
        private IMediator Mediator { get; set; }

        public PersonController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        [HttpGet(Name = "GetPerson")]
        public IEnumerable<object> Get()
        {   
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a Person.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A newly created Person</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /person
        ///     {
        ///       "name": "João Alberto",
        ///       "sex": "Male",
        ///       "email": joao_alberto@gmail.com,
        ///       "birthDate": "2000-03-06",
        ///       "placeOfBirth": "Sobral-CE",
        ///       "nationality": "Brasilerio",
        ///       "cpf": "12312312312"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If some information on the request is invalid</response>
        /// <response code="500">If some server side error occur</response>
        [HttpPost(Name = "CreatePerson")]
        [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] CreatePersonCommand command, CancellationToken cancellationToken = default)
        {
            PersonDTO dto = await Mediator.Send(command, cancellationToken);
            // TODO: return 201 Created with the uri to the created resource, once the get by id endpoint is implemented
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
