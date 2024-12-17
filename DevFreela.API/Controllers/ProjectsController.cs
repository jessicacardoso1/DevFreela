using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Models;
using MediatR;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.CompleteProject;
using DevFreela.Application.Commands.InsertComment;
using Microsoft.AspNetCore.Authorization;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly FreelanceTotalCostConfig _config;
        private readonly IMediator _mediator;
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/projects?search=crm
        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get(string search = "", int page = 0, int size = 3)
        {
            var query = new GetAllProjectsQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // GET api/projects/1234
        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // POST api/projects
        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post(InsertProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data}, command);
        }

        // PUT api/projects/1234
        [HttpPut("{id}")]
        [Authorize(Roles = "client")]

        public async Task<IActionResult> Put(int id, UpdateProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //  DELETE api/projects/1234
        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            var result = await _mediator.Send(new StartProjectCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await _mediator.Send(new CompleteProjectCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> PostComment(int id, InsertCommentCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
