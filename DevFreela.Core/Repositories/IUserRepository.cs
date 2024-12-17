using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int id);
        Task<int> Add(User user);
        Task PostSkills(int userId, List<int> skillIds);
        Task Update(User user);
        Task<bool> Exists(int id);
        Task<User> GetUserByEmailAndPassordAsync(string email, string passwordHash);
    }
}
