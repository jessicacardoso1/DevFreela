using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevFreela.Application.Models;
using MediatR;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Application.Commands.InsertSkillsUser;
using DevFreela.Application.Queries.GetSkillById;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DevFreela.Application.Commands.UpdateSkill;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.DeleteSkill;
using DevFreela.Application.Commands.InsertSkill;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSkillsQuery();
            var skills = await _mediator.Send(query);

            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var result = await _mediator.Send(new GetSkillByIdQuery(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteSkillCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSkillCommand command)
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
