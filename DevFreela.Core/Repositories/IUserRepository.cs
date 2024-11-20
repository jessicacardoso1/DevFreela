using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int id);
        Task<int> Add(User user);
        //Task<int> PostSkills(int id, UserSkill userSkill);
        Task Update(User user);
        Task<bool> Exists(int id);
    }
}
