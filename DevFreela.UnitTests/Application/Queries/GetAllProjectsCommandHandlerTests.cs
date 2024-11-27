using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome Do Teste 1", "Descricao De Teste 1", 1, 2, 10000),
                new Project("Nome Do Teste 2", "Descricao De Teste 2", 1, 2, 20000),
                new Project("Nome Do Teste 3", "Descricao De Teste 3", 1, 2, 30000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAll().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsHandler = new GetAllProjectsHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModelList = await getAllProjectsHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList.Data);
            Assert.Equal(projects.Count, projectViewModelList.Data.Count);

            projectRepositoryMock.Verify(pr => pr.GetAll().Result, Times.Once);
        }
    }
}
