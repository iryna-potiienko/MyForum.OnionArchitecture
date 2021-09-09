using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using MyForum.Models;

namespace Persistence.Context
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}