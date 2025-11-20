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
        public ActionResult Authenticate([FromBody] UserCredentials userCredentials, CancellationToken ct = default)
        {

            return Ok(userCredentials);
        }
    }
}
