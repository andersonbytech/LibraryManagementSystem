using Dapper;
using System.Data;
using Library.Shared;


namespace Library.Infrastructure.Queries
{
    public class GetBookIdQueryHandler
    {

        private readonly IDbConnection  _dbConnection;

        public GetBookIdQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;   
        }
        public async Task<Book> Handle(int id)
        {
            var sql = "SELECT * FROM Books WHERE id = @Id";
            
            Book book = await _dbConnection.QueryFirstOrDefaultAsync<Book>(sql, new { Id = id });
                   
            return book;
        }

    }
}
