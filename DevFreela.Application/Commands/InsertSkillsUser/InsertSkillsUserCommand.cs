﻿using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertSkillsUser
{
    public class InsertSkillsUserCommand : IRequest<ResultViewModel<int>>
    {
        public int[] SkillIds { get; set; }
        public int Id { get; set; }
    }
}
