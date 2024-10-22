using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _context;
        public UserService(DevFreelaDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var user = _context.Users.
                FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("User não existe");
            }
            user.SetAsDeleted();
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();

        }

        public ResultViewModel<List<UserViewModel>> GetAll(string search = "")
        {
            var users = _context.Users
                .Include(u => u.Skills)
                   .ThenInclude(u => u.Skill)
                .Where(u => !u.IsDeleted).ToList();

            var model = users.Select(UserViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserViewModel>>.Success(model);
        }

        public ResultViewModel<UserViewModel> GetById(int id)
        {
            var user = _context.Users
               .Include(u => u.Skills)
                   .ThenInclude(u => u.Skill)
               .SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuario não existe");
            }

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateUserInputModel model)
        {
            var user = model.ToEntity();

            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(user.Id);
        }

        public ResultViewModel InsertSkills(int id, UserSkillsInputModel model)
        {
            var userSkils = model.SkillIds.Select(s => new UserSkill(id, s)).ToList();
            _context.AddRange(userSkils);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Update(UpdateUserInputModel model)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Id == model.IdUser);
            if (user is null) {
                return ResultViewModel.Error("User não existe");
            }

            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
