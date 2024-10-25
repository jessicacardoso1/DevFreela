using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _context;

        public ResultViewModel Delete(int id)
        {

            var skill = _context.Skills.SingleOrDefault(s => s.Id == id);

            if (skill is null)
            {
                return ResultViewModel.Error("Skill não encontrada");
            }

            skill.SetAsDeleted();
            _context.Skills.Update(skill);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<SkIllViewModel>> GetAll(string search = "")
        {
            var skills = _context.Skills
                .Where(s => s.Description.Contains(search))
                .ToList();

            var model = skills.Select(SkIllViewModel.FromEntity).ToList();

            return ResultViewModel<List<SkIllViewModel>>.Success(model);
        }

        public ResultViewModel<SkIllViewModel> GetById(int id)
        {
            var skill = _context.Skills
                .SingleOrDefault(s => s.Id == id);

            if (skill is null) {
                return ResultViewModel<SkIllViewModel>.Error("Skill não encontrada");
            }

            var model = SkIllViewModel.FromEntity(skill);
            
            return ResultViewModel<SkIllViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateSkillInputModel model)
        {
            var skill = model.ToEntity();

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(skill.Id);
        }

        public ResultViewModel Update(UpdateSkillInputModel model)
        {
            var skill = _context.Skills.SingleOrDefault(u => u.Id == model.IdSkill);
            
            if (skill is null) {
                return ResultViewModel.Error("Skill não encontrada");
            }
                skill.Update(model.Descricao);

            _context.Update(skill);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
