using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<UserSkill> UserSkill { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Skill>(e =>
                {
                    e.HasKey(s => s.Id);
                });

            builder
                .Entity<UserSkill>(e =>
                {
                    e.HasKey(us => us.Id);
                    e.HasOne(u => u.Skill)
                        .WithMany(u => u.UserSkill)
                        .HasForeignKey(s => s.IdSkill)
                        .OnDelete(DeleteBehavior.Restrict);

                });

            builder
                .Entity<ProjectComment>(e =>
                {
                    e.HasKey(pc => pc.Id);

                    e.HasOne(pc => pc.Project)
                         .WithMany(p => p.Comments)
                         .HasForeignKey(pc => pc.IdProject)
                         .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(p => p.User)
                        .WithMany(u => u.Comments)
                        .HasForeignKey(p => p.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);

                });


            builder
                .Entity<User>(e =>
                {
                    e.HasKey(u => u.Id);
                    e.HasMany(u => u.Skills)
                        .WithOne(us => us.User)
                        .HasForeignKey(us => us.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);

                });

            builder
                .Entity<Project>(e =>
                {
                    e.HasKey(u => u.Id);

                    e.HasOne(p => p.Freelancer)
                    .WithMany(c => c.FreelanceProjects)
                    .HasForeignKey(p => p.IdFreelancer)
                    .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(p => p.Client)
                    .WithMany(c => c.OwnedProjects)
                    .HasForeignKey(p => p.IdClient)
                    .OnDelete(DeleteBehavior.Restrict);
                });
        }


    }
}
