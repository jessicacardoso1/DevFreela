using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int id)
        {
            return Ok();
        }

    }
}
