using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Features.ChapterFeatures.Commands
{
    public class UpdateChapterCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class UpdateChapterCommandHandler : IRequestHandler<UpdateChapterCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateChapterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateChapterCommand command, CancellationToken cancellationToken)
            {
                var chapter = _context.Chapters.FirstOrDefault(a => a.Id == command.Id);

                if (chapter == null)
                {
                    return default;
                }
                else
                {
                    chapter.Name = command.Name;
                    chapter.Description = command.Description;
                    await _context.SaveChangesAsync();
                    return chapter.Id;
                }
                
            }
        }
    }
}