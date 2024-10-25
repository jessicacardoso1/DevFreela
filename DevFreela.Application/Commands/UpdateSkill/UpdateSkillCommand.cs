using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateSkill
{
    public class UpdateSkillCommand : IRequest<ResultViewModel>
    {
        public int IdSkill { get; set; }

        public string Descricao { get; set; }
    }
}
