using Azure.Core;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;


namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectHandle : IRequestHandler<UpdateProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public UpdateProjectHandle(IProjectRepository repository)
        {
            _repository = repository;

        }
        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.IdProject);
            if (project is null)
            {
                return ResultViewModel.Error("Prtojeto não existe.");
            }
            project.Update(request.Title, request.Description, request.TotalCost);

            await _repository.Update(project);

            return ResultViewModel.Success();

        }
    }
}
