using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        public readonly DevFreelaDbContext _context;

        public SkillRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Skill skill)
        {

            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Skills.AnyAsync(x => x.Id == id);

        }

        public async Task<List<Skill>> GetAll()
        {
            var skills = await _context.Skills
                .Where(s => !s.IsDeleted)
                .ToListAsync();

            return skills;
        }

        public async Task<Skill> GetById(int id)
        {
            var skill = await _context.Skills.SingleOrDefaultAsync(x => x.Id == id);

            return skill;
        }

        public async Task Update(Skill skill)
        {
            _context.Update(skill);
            await _context.SaveChangesAsync();
        }
    }
}
