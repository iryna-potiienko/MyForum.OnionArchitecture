using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
using MyForum.Models;

namespace Application.Features.ChapterFeatures.Commands
{
    public class CreateChapterCommand: IRequest<Chapter>
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
 
        public class CreateChapterCommandHandler : IRequestHandler<CreateChapterCommand, Chapter>
        {
            private readonly IApplicationDbContext _context;
            public CreateChapterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Chapter> Handle(CreateChapterCommand command, CancellationToken cancellationToken)
            {
                var chapter = new Chapter {Name = command.Name, Description = command.Description};

                _context.Chapters.Add(chapter);
                await _context.SaveChangesAsync();
                return chapter;
            }
        }
    }
}