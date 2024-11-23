using Azure.Core;
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertSkillsUser
{
    public class InsertSkillsUserHandler : IRequestHandler<InsertSkillsUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;
        public InsertSkillsUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertSkillsUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.PostSkills(request.Id, request.SkillIds.ToList());

            return ResultViewModel<int>.Success(request.Id);
        }

    }
}
