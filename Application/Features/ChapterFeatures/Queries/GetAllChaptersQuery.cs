using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyForum.Models;

namespace Application.Features.ChapterFeatures.Queries
{
    public class GetAllChaptersQuery: IRequest<IEnumerable<Chapter>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllChaptersQuery, IEnumerable<Chapter>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Chapter>> Handle(GetAllChaptersQuery query, CancellationToken cancellationToken)
            {
                var chaptersList = //await _context.Chapters.ToListAsync();
                await _context.Chapters
                    .Include(s=>s.Subjects)
                    .ThenInclude(m=>m.Messages)
                    .ToListAsync();
                /*if (productList == null)
                {
                    return null;
                }*/
                return chaptersList; //.AsReadOnly();
            }
        }
    }
}