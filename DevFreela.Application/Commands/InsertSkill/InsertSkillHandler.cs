using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertSkill
{
    public class InsertSkillHandler : IRequestHandler<InsertSkillCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;
        public InsertSkillHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(InsertSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = request.ToEntity();

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(skill.Id);
        }
    }
}
