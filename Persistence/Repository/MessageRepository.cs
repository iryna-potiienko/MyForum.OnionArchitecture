using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Persistence.Repository
{
    public class MessageRepository
    {
        private readonly IApplicationDbContext _context;

        public MessageRepository(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Message> Create(Message message)
        {
            var subject = await _context.Subjects.FindAsync(message.SubjectId);
            
            var userProfile =  _context.UserProfiles.FirstOrDefault(m => m.UserName==message.UserName);
            if (subject==null)
            {
                return null;
            }
            if (userProfile==null)
            {
                return null;
            }
            
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return message;
        }

        public Task<List<Message>> FindAll()
        {
            return _context.Messages.ToListAsync();
        }

        public Message FindById(int id)
        {
            return _context.Messages.Find(id);
        }


        public void Update(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
        }

        public void Delete(Message message)
        {
            _context.Messages.Remove(message);
            _context.SaveChanges();
        }
    }
}