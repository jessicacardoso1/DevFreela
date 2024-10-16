using DevFreela.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services
{
    public interface IUserService
    {
        ResultViewModel<ProjectViewModel> GetById(int id);

        ResultViewModel<ProjectViewModel> Insert(CreateUserInputModel model);
        ResultViewModel<ProjectViewModel> Delete(int id);
        ResultViewModel<ProjectViewModel> Update(CreateUserInputModel model);
        ResultViewModel<ProjectViewModel> PostSkills(int id, UserSkillsInputModel model);
    }
}
