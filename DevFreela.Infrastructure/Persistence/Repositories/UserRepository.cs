
using Azure.Core;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;
        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> Exists(int id)
        {
           return await _context.Users.AnyAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users
              .Include(u => u.Skills)
                 .ThenInclude(us => us.Skill)
              .Where(u => !u.IsDeleted).ToListAsync();

            return users;
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                    .ThenInclude(us => us.Skill)
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<User> GetUserByEmailAndPassordAsync(string email, string passwordHash)
        {
            return await _context
                .Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }

        public async Task PostSkills(int userId, List<int> skillIds)
        {
            var userSkills = skillIds.Select(skillId => new UserSkill(userId, skillId)).ToList();

            await _context.AddRangeAsync(userSkills);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
