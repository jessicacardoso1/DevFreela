using Azure.Core;
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

namespace DevFreela.Application.Queries.GetSkillById
{
    public class GetSkillByIdHandler : IRequestHandler<GetSkillByIdQuery, ResultViewModel<SkIllViewModel>>
    {
        private readonly ISkillRepository _repository;
        public GetSkillByIdHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<SkIllViewModel>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetById(request.Id);

            if (skill is null)
            {
                return ResultViewModel<SkIllViewModel>.Error("Skill não encontrada");
            }

            var model = SkIllViewModel.FromEntity(skill);

            return ResultViewModel<SkIllViewModel>.Success(model);
        }
    }
}
