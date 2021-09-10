using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Persistence.Context
{
    public class ApplicationDbContext: IdentityDbContext<UserProfile>, IApplicationDbContext
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.UserProfile)
                .WithMany(u => u.Subjects)
                .HasForeignKey(s => s.UserName)
                .HasPrincipalKey(u=>u.UserName);
            
            modelBuilder.Entity<Message>()
                .HasOne(s => s.UserProfile)
                .WithMany(u => u.Messages)
                .HasForeignKey(s => s.UserName)
                .HasPrincipalKey(u=>u.UserName);
        }
    }
}