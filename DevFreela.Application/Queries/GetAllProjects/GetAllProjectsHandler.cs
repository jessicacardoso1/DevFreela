using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsHandler(IProjectRepository repository)
        {
            _repository = repository;

        }
        public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAll();

            //var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();
            var model = projects.Select(project =>
                new ProjectItemViewModel(
                    project.Id,
                    project.Title,
                    project.Description,
                    project.Client?.FullName ?? "Cliente não informado",
                    project.Freelancer?.FullName ?? "Freelancer não informado",
                    project.TotalCost
                )
            ).ToList();

            return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
        }
    }
}

