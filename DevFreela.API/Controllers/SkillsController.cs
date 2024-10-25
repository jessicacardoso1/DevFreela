using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevFreela.Application.Models;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        public SkillsController(DevFreelaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var skills = _context.Skills.
                ToList();

            var model = skills.Select(SkIllViewModel.FromEntity).ToList();
            return Ok(skills);
        }

        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model)
        {
            var skill = new Skill(model.Description);

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(UpdateSkillInputModel model) {
            return Ok();
        }
    }

}
