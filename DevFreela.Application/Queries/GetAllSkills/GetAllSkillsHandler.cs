using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
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
        private readonly DevFreelaDbContext _context;
        public GetAllSkillsHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<SkIllViewModel>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _context.Skills
            .ToListAsync();

            var model = skills.Select(SkIllViewModel.FromEntity).ToList();

            return ResultViewModel<List<SkIllViewModel>>.Success(model);
        }
    }
}
