using DevFreela.Application.Commands.InsertUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Commands
{
    public class InsertUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            //// Arrange
            //var userRepository = new Mock<IUserRepository>();

            ////var insertUserCommand = new InsertUserCommand
            ////{
            ////    FullName = "Jéssica",
            ////    Email = "jessica.cardosor@gmail.com",
            ////    BirthDate = DateTime.Now,
            ////    Role = "client"
            ////};

            ////var insertUserCommandHandler = new InsertUserHandler(userRepository.Object);

            //// Act
            //var id = await insertUserCommandHandler.Handle(insertUserCommand, new CancellationToken());

            //// Assert
            //Assert.True(id.Data >= 0);

            //userRepository.Verify(u => u.Add(It.IsAny<User>()), Times.Once);
        }
    }
}
