using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonCRUD.Application.Commands.GenerateAccessTokenCommand;
using PersonCRUD.Application.DTOs;
using PersonCRUD.Server.Records;
using System.Text;

namespace PersonCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class UserController(IMediator mediator, IConfiguration configuration) : ControllerBase
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
        [HttpPost("Authenticate", Name = "Authenticate")]
        [ProducesResponseType(typeof(TokenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenDTO), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Authenticate([FromBody] UserCredentials userCredentials, CancellationToken ct = default)
        {
            GenerateAccessTokenCommand command = new (
                userCredentials.Email,
                userCredentials.Password,
                new JwtInfo(
                    JwtIssuer: configuration["Jwt:Issuer"],
                    JwtAudience: configuration["Jwt:Audience"],
                    JwtKey: Encoding.ASCII.GetBytes(configuration["Jwt:Key"])
                )
            );

            TokenDTO response = await mediator.Send(command, ct);

            if (response.Success)
                return Ok(response);

            return Unauthorized(response);
        }
    }
}
