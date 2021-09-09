using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyForum.Models;

namespace Persistence.Repository
{
    public class SubjectRepository
    {
        private readonly IApplicationDbContext _context;

        public SubjectRepository(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        
        public async Task<Subject> Create(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return subject;
        }

        public Task<List<Subject>> FindAll()
        {
            return _context.Subjects.ToListAsync();
        }
        
        public Subject FindById(int id)
        {
            return _context.Subjects.Find(id);
        }
        
        public void Update(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        public void Delete(Subject subject)
        {
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
        }
    }
}