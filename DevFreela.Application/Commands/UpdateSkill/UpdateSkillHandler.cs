using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateSkill
{
    public class UpdateSkillHandler : IRequestHandler<UpdateSkillCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;
        public UpdateSkillHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills.SingleOrDefaultAsync(u => u.Id == request.IdSkill);

            if (skill is null)
            {
                return ResultViewModel.Error("Skill não encontrada");
            }
            skill.Update(request.Descricao);

            _context.Update(skill);
            _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
