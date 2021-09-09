using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ChapterFeatures.Commands
{
    public class DeleteChapterCommand: IRequest<int>
    {
    public int Id { get; set; }
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteChapterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public DeleteProductByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteChapterCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Chapters.FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);
            if (product == null) return default;
            _context.Chapters.Remove(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
    }
}