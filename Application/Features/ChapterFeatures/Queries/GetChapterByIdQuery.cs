using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyForum.Models;

namespace Application.Features.ChapterFeatures.Queries
{
    public class GetChapterByIdQuery : IRequest<Chapter>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetChapterByIdQuery, Chapter>
        {
            private readonly IApplicationDbContext _context;
            public GetProductByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Chapter> Handle(GetChapterByIdQuery query, CancellationToken cancellationToken)
            {
                //var product = _context.Chapters.Where(a => a.Id == query.Id).FirstOrDefault();
                var chapter = await _context.Chapters
                    .Include(m=>m.Subjects)
                    .ThenInclude(s=>s.Messages)
                    .Where(s=>s.Id == query.Id)
                    .FirstOrDefaultAsync();
                //if (chapter == null) return null;
                
                return chapter;
            }
        }
    }
}