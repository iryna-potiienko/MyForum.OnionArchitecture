using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Persistence.Repository
{
    public class ChapterRepository
    {

        private readonly IApplicationDbContext _context;

        public ChapterRepository(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        
        public async Task<Chapter> Create(Chapter chapter)
        {
            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();

            return chapter;
        }

        public Task<List<Chapter>> FindAll()
        {
            return _context.Chapters.ToListAsync();
        }
        
        public Chapter FindById(int id)
        {
            return _context.Chapters.Find(id);
        }

        
        public void Update(Chapter chapter)
        {
            _context.Chapters.Update(chapter);
            _context.SaveChanges();
        }

        public void Delete(Chapter chapter)
        {
            _context.Chapters.Remove(chapter);
            _context.SaveChanges();
        }
    }
}