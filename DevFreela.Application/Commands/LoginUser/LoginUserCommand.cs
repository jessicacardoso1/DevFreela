﻿using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<ResultViewModel<LoginUserViewModel>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
