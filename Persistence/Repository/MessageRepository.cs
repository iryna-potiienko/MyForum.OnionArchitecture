using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyForum.Models;

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