using Microsoft.EntityFrameworkCore;
using Library.Shared;


namespace Library.Infrastructure.Data
{
    public class WriteContext : DbContext
    {
        public WriteContext(DbContextOptions<WriteContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
