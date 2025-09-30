using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PersonCRUD.Application.Commands.CreatePersonCommand;
using PersonCRUD.Application.Commands.DeletePersonCommand;
using PersonCRUD.Application.Commands.UpdatePersonCommand;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Application.Querys.GetPersonByIdQuery;
using PersonCRUD.Application.Querys.GetPersonPaginatedQuery;
using PersonCRUD.Server.Models.Request;
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

        // TODO: documentar exemplos de request para todos os endpoints

        /// <summary>
        /// Returns a paginated list of persons.
        /// </summary>
        /// <returns>A list of persons in the specified page</returns>
        /// <param name="pageSize">Number of records per page</param>
        /// <param name="currentPage">Page index starting from 1</param>
        /// <response code="200">A list of persons in the specified page</response>
        /// <response code="400">If some query parameter is invalid</response>
        /// <response code="500">If some server side error occur</response>
        [HttpGet(Name = "GetAllPerson")]
        [ProducesResponseType(typeof(List<PersonDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPaginated([FromQuery] int currentPage, [FromQuery] int pageSize, CancellationToken ct = default)
        {
            GetPersonPaginatedQuery command = new GetPersonPaginatedQuery(currentPage, pageSize);
            List<PersonDTO> dto = await Mediator.Send(command, ct);
            return Ok(dto);
        }

        /// <summary>
        /// Searches for a person.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The person infromation</returns>
        /// <response code="200">Returns the person infromation</response>
        /// <response code="404">If there is no person with the id informed in the database</response>
        /// <response code="500">If some server side error occur</response>
        [HttpGet("{id}", Name = "GetPerson")]
        [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get([FromRoute] long id, CancellationToken ct = default)
        {
            GetPersonByIdQuery query = new GetPersonByIdQuery(id);
            PersonDTO dto = await Mediator.Send(query, ct);
            return Ok(dto);
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
        ///       "email": "joao_alberto@gmail.com",
        ///       "birthDate": "2000-03-06",
        ///       "placeOfBirth": "Sobral-CE",
        ///       "nationality": "Brasilerio",
        ///       "cpf": "12312312312"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If some information on the request is invalid</response>
        /// <response code="500">If some server side error occur</response>
        [HttpPost(Name = "CreatePerson")]
        [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] CreatePersonCommand command, CancellationToken ct = default)
        {
            PersonDTO dto = await Mediator.Send(command, ct);
            return Created($"{Request.GetDisplayUrl()}/{dto.Id}", dto);
        }

        /// <summary>
        /// Updates the Person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>A newly updated Person</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /person/{id}
        ///     {
        ///       "name": "João Alberto",
        ///       "sex": "Male",
        ///       "email": "joao_alberto@gmail.com",
        ///       "birthDate": "2000-03-06",
        ///       "placeOfBirth": "Sobral-CE",
        ///       "nationality": "Brasilerio",
        ///       "cpf": "12312312312"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If some information on the request is invalid</response>
        /// <response code="404">If there is no person with the given id in the database</response>
        /// <response code="500">If some server side error occur</response>
        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put([FromRoute] long id, [FromBody] UpdatePersonRequest request, CancellationToken ct = default)
        {
            UpdatePersonCommand command = new UpdatePersonCommand(
                id: id,
                name: request.Name,
                sex: request.Sex,
                email: request.Email,
                birthDate: request.BirthDate,
                placeOfBirth: request.PlaceOfBirth,
                nationality: request.Nationality,
                cpf: request.CPF
            );

            PersonDTO dto = await Mediator.Send(command, ct);
            return Ok(dto);
        }

        /// <summary>
        /// Deletes a person.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The person infromation</returns>
        /// <response code="204">Returns empty body, the person was deleted successfully</response>
        /// <response code="404">If there is no person with the id informed in the database</response>
        /// <response code="500">If some server side error occur</response>
        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([FromRoute] long id, CancellationToken ct = default)
        {
            DeletePersonCommand command = new DeletePersonCommand(id);
            await Mediator.Send(command, ct);
            return NoContent();
        }
    }
}
