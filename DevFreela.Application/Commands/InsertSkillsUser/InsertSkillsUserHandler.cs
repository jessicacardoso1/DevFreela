using Azure.Core;
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertSkillsUser
{
    public class InsertSkillsUserHandler : IRequestHandler<InsertSkillsUserCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;
        public InsertSkillsUserHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(InsertSkillsUserCommand request, CancellationToken cancellationToken)
        {
           var userSkils = request.SkillIds.Select(s => new UserSkill(request.Id, s)).ToList();
           await _context.AddRangeAsync(userSkils);
           await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
