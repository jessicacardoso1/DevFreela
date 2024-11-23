using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
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
        private readonly ISkillRepository _repository;
        public UpdateSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetById(request.IdSkill);

            if (skill is null)
            {
                return ResultViewModel.Error("Skill não encontrada");
            }
            skill.Update(request.Descricao);

            _repository.Update(skill);

            return ResultViewModel.Success();
        }
    }
}
