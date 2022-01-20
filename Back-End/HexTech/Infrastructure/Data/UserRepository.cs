using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("hextech");
        }
        
        public IEnumerable<User> GetAll()
        {
            const string query = @"
SELECT
    id_user as IdUser,
    psw as Password,
    permission
FROM
    users;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.Query<User>(query);
        }

        public User GetByName(string name, string password)
        {
            const string query = @"
SELECT
    id_user as IdUser,
    psw as Password,
    permission
FROM
    users
WHERE
    id_user = @name
    AND
    psw = @password;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.QueryFirstOrDefault<User>(query, new { name, password });
        }
    }
}
