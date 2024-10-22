using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;
        public UpdateUserHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id == request.IdUser);
            if (user is null)
            {
                return ResultViewModel.Error("Usuario não existe.");
            }
            user.Update(request.FullName, request.Email, request.BirthDate);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();

        }
    }
}
