using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace API.Data
{
    public class DataContext
    {
        private readonly string _connectionString;

        public DataContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("Database").Value;
        }

        public IDbConnection DapperConnection => new NpgsqlConnection(_connectionString);

    }
}
