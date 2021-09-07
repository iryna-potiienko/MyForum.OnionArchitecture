using Microsoft.EntityFrameworkCore;
using MyForum.Models;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Chapter> Chapters { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<UserProfile> UserProfiles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<UserRoleMapping> UserRoleMappings { get; set; }
    }
}