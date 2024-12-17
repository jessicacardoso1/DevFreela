using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertUser
{
    public class InsertUserCommand : IRequest<ResultViewModel<int>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public User ToEntity()
            => new(FullName, Email, BirthDate, Password, Role);

        public void SetHashedPassword(string password) {
            Password = password;
        }
    }
}
