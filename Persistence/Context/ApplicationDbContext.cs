using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyForum.Models;

namespace Persistence.Context
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            //Database.EnsureCreated();
        }
    }
}