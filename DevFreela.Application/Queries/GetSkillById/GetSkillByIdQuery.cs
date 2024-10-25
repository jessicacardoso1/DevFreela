using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetSkillById
{
    public class GetSkillByIdQuery : IRequest<ResultViewModel<SkIllViewModel>>
    {
        public GetSkillByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
