using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
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
        private readonly ISkillRepository _repository;
        public DeleteSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetById(request.Id);

            if (skill is null)
            {
                return ResultViewModel<SkIllViewModel>.Error("Skill não encontrada");
            }

            skill.SetAsDeleted();
            await _repository.Update(skill);

            return ResultViewModel.Success();
        }
    }
}
