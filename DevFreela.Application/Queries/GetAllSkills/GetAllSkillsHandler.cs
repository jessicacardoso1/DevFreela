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

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsQuery, ResultViewModel<List<SkIllViewModel>>>
    {
        private readonly ISkillRepository _repository;
        public GetAllSkillsHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<SkIllViewModel>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetAll();

            var model = skills.Select(SkIllViewModel.FromEntity).ToList();

            return ResultViewModel<List<SkIllViewModel>>.Success(model);
        }
    }
}
