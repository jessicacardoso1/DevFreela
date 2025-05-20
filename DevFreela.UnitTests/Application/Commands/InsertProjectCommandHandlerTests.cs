using DevFreela.Application.Commands.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using IdentityModel.OidcClient;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class InsertProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var createProjectCommand = new InsertProjectCommand
            {
                Title = "Titulo de Teste",
                Description = "Uma descrição Daora",
                TotalCost = 50000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var createProjectCommandHandler = new InsertProjectHandler(projectRepository.Object);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(id.Data >= 0);

            projectRepository.Verify(pr => pr.Add(It.IsAny<Project>()), Times.Once);
        }

        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId_NSubstitute()
        {
            // Arrange
            const int ID = 1;
            var projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.Add(Arg.Any<Project>()).Returns(Task.FromResult(ID));

            var createProjectCommand = new InsertProjectCommand
            {
                Title = "Titulo de Teste",
                Description = "Uma descrição Daora",
                TotalCost = 50000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var createProjectCommandHandler = new InsertProjectHandler(projectRepository);

            // Act
            var result = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data);

            projectRepository.Received(1).Add(Arg.Any<Project>());
        }
    }
}
