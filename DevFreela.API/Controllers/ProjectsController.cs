using DevFreela.API.Models;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly FreelanceTotalCostConfig _config;
        private readonly IConfigService _configService;
        public ProjectsController(IOptions<FreelanceTotalCostConfig> options, IConfigService configService) {
            _config = options.Value;
            _configService = configService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string search = "")
        {
            //return not found()
            return Ok(_configService.GetValue());
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel model)
        {
            if (model.TotalCost < _config.Minimum || model.TotalCost > _config.Maximum )
            {
                return BadRequest("Numero fora dos limites.");
            }
            return CreatedAtAction(nameof(GetById), new { search = model.Title }, model);
        }
        //PUT api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel model)
        {
            if (model.Description.Length > 50)
            {
                return BadRequest();
            }
            model.Id = id;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();

        }

        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            return NoContent();

        }

        [HttpPost("{id}/comments")]
        public IActionResult Comments(int id, CreateProjectCommentInputModel model)
        {
            return Ok();
        }
    }
}
