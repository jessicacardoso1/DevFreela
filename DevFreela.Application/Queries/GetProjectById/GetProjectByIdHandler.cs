using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdHandler(IProjectRepository repository)
        {
            _repository = repository;

        }
        public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetDetailsByID(request.Id);
            if (projects is null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
            }
            var model = ProjectViewModel.FromEntity(projects);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }
    }
}
