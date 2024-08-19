using Dapper;
using System.Data;
using Library.Shared;

namespace Library.Infrastructure.Queries
{
    public class GetAllBooksQueryHandler
    {
        private readonly IDbConnection _dbConnection;

        public GetAllBooksQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Book>> Handle()
        {
            var sql = "SELECT * FROM Books";
            return await _dbConnection.QueryAsync<Book>(sql);
        }
    }

}
