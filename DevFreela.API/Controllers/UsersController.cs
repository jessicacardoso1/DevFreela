﻿using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevFreela.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Commands.InsertUser;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.DeleteUser;
using DevFreela.Application.Commands.UpdateUser;
using DevFreela.Application.Commands.InsertSkillsUser;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DevFreela.Application.Queries.GetUserById;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetAllUsers;
using DevFreela.Application.Commands.LoginUser;
using Microsoft.AspNetCore.Authorization;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPost("{id}/skills")]
        public async Task<IActionResult> PostSkills(int id, InsertSkillsUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok();
        }

        // GET api/projects?search=crm
        [HttpGet]
        public async Task<IActionResult> Get(string search = "", int page = 0, int size = 3)
        {
            var query = new GetAllUsersQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile file)
        {

            var description = $"File: {file.FileName}, Size: {file.Length}";
            //processa a imagem
            return Ok(description);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

    }
}
