using Microsoft.AspNetCore.Mvc;
using PersonCRUD.Server.Records;

namespace PersonCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost(Name = "Authenticate")]
        //[ProducesResponseType(typeof(PersonDTO), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public ActionResult Authenticate([FromBody] UserCredentials userCredentials, CancellationToken ct = default)
        {

            return Ok(userCredentials);
        }
    }
}
