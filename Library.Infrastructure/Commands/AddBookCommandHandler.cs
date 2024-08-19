using Library.Infrastructure.Data;
using Library.Shared;

namespace Library.Infrastructure.Commands
{
    public class AddBookCommandHandler
    {
        private readonly WriteContext _context;

        public AddBookCommandHandler(WriteContext context)
        {
            _context = context;
        }

        public async Task Handle(AddBookCommand command)
        {
            var book = new Book
            {
                Title = command.Title,
                Author = command.Author,
                PublishedDate = command.PublishedDate,
                ISBN = command.ISBN,
                Pages = command.Pages
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
    }
}
