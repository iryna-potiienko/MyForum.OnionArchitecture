using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<Chapter> Chapters { get; set; }
        
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public  Task<int> SaveChangesAsync();

        public void SaveChanges();
    }
}