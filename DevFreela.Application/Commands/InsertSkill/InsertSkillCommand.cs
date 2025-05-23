﻿using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertSkill
{
    public class InsertSkillCommand : IRequest<ResultViewModel<int>> {
        public string Description { get; set; }
        public Skill ToEntity()
            => new(Description);
    }
}
