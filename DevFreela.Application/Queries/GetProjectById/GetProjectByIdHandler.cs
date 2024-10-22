using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _context;
        public GetProjectByIdHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _context.Projects
              .Include(p => p.Client)
              .Include(p => p.Freelancer)
              .Include(p => p.Comments)
              .SingleOrDefaultAsync(p => p.Id == request.Id);
            if (projects is null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
            }
            var model = ProjectViewModel.FromEntity(projects);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }
    }
}
