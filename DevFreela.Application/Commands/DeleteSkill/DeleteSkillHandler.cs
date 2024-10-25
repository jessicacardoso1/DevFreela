using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteSkill
{
    public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;
        public DeleteSkillHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = _context.Skills.SingleOrDefault(s => s.Id == request.Id);

            if (skill is null)
            {
                return ResultViewModel.Error("Skill não encontrada");
            }

            skill.SetAsDeleted();
            _context.Skills.Update(skill);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
