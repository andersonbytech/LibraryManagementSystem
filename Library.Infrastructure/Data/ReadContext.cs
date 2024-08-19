using Microsoft.EntityFrameworkCore;
using Library.Shared;


namespace Library.Infrastructure.Data
{
    public class ReadContext : DbContext
    {
        public ReadContext(DbContextOptions<ReadContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }

        public ReadContext()
        {
        }


    }
}
