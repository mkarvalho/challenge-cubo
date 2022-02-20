using API.Data;
using API.Model;
using API.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class PersonRepository : DataContext , IPersonRepository
    {
        public PersonRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Create(Person obj)
        {
            using IDbConnection conn = DapperConnection;
            var sql = "INSERT INTO Person Values(@Id, @Name, @LastName, @Participation)";
            await conn.QueryAsync<Person>(sql, new { obj.Id, obj.Name, obj.LastName, obj.Participation });        
        }

        public async Task<IList<Person>> GetAll()
        {
            using IDbConnection conn = DapperConnection;
            var sql = "SELECT * FROM Person";
            var result = await conn.QueryAsync<Person>(sql);
            return result.OrderByDescending(x => x.Id).ToList();
        }

        public async Task<Person> GetById(Guid id)
        {
            using IDbConnection conn = DapperConnection;
            var sql = "SELECT * FROM Person WHERE Id=@id";
            var result = await conn.QueryAsync<Person>(sql, new { id });
            return result.SingleOrDefault();
        }

        public async Task Remove(Guid id)
        {
            using IDbConnection conn = DapperConnection;
            var sql = "DELETE FROM Person WHERE Id=@id";
            await conn.QueryAsync<Person>(sql, new { id });
        }

        public async Task Update(Person obj, Guid id)
        {
            using IDbConnection conn = DapperConnection;
            var sql = "UPDATE Person SET Name=@Name, LastName=@LastName, Participation=@Participation WHERE Id=@id";
            await conn.QueryAsync<Person>(sql, new { obj.Name, obj.LastName, obj.Participation, Id = id });
            
        }
    }
}
