using Library.Infrastructure.Data;
using Library.Shared;

namespace Library.Infrastructure.Commands
{
    public class DeleteBookCommandHandler
    {
        private readonly WriteContext _context;

        public  DeleteBookCommandHandler(WriteContext context)
        {
            _context = context;
        }

        public async Task Handle(Book book)
        {
            _context.Remove(book);
           await _context.SaveChangesAsync();
        }
    }
}
