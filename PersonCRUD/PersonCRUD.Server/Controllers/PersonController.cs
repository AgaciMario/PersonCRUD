using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<object> Post()
        {
            throw new NotImplementedException();
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
