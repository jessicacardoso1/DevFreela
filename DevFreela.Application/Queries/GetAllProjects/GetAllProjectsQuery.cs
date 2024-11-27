using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
    {
        public GetAllProjectsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}

