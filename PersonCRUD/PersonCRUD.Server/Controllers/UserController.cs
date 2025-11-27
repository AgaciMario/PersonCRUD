using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonCRUD.Application.Commands.LoginCommand;
using PersonCRUD.Server.Records;

namespace PersonCRUD.Server.Controllers
{
    //TODO: avaliar controller pois ela aparentemente não esta seguindo os principios REST;
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Provide a Json Web Token for user authentication and authorization.
        /// </summary>
        /// <param name="userCredentials">The Registered user Email and Password</param>
        /// <returns>A Json Web Token(JWT) in compact format</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /user/authenticate
        ///     {
        ///         "Email": "sample@email.com",
        ///         "Password": "123456"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the created Json Web Token(JWT) in compact format</response>
        /// <response code="401">User credentials are incorrect or user is not registered in the database</response>
        /// <response code="500">If some server side error occur</response>
        [HttpPost("Login", Name = "Login")]
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] UserCredentials userCredentials, CancellationToken ct = default)
        {
            LoginCommand command = new(userCredentials.Email, userCredentials.Password);
            string response = await mediator.Send(command, ct);
            return Ok(new TokenResponse(response));
        }
    }
}
