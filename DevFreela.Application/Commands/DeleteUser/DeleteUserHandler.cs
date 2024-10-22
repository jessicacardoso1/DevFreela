using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;
        public DeleteUserHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id == request.Id);
            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Projeto não existe");
            }

            user.SetAsDeleted();
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
