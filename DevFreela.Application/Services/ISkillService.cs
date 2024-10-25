using DevFreela.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services
{
    public interface ISkillService
    {
        ResultViewModel<List<SkIllViewModel>> GetAll(string search = "");
        ResultViewModel<SkIllViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateSkillInputModel model);
        ResultViewModel Update(UpdateSkillInputModel model);
        ResultViewModel Delete(int id);

    }
}
