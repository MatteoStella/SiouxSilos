using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Data;

namespace Infrastructure.Data
{
    public class WarningSettingRepository : IWarningSettingRepository
    {
        private readonly string _connectionString;

        public WarningSettingRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("hextech");
        }

        public IEnumerable<WarningSetting> GetWarnings()
        {
            const string query = @"
SELECT
    Id,
    Id_Silos as IdSilos,
    temperature as temperatura,
    humidity as umidita,   
    pressure as pressione
FROM
    warning_setting;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.Query<WarningSetting>(query);
        }

        public WarningSetting GetBySilosId(int id)
        {
            const string query = @"
SELECT
    Id,
    Id_Silos as IdSilos,
    temperature as temperatura,
    humidity as umidita,   
    pressure as pressione
FROM
    warning_setting
WHERE
    id_silos = @id;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.QueryFirstOrDefault<WarningSetting>(query, new { id });
        }

        public void Inser(WarningSetting alarm)
        {
            const string query = @"
INSERT INTO warning_setting(
    Id_Silos,
    temperature,
    humidity,
    pressure)
VALUES(
    @IdSilos,
    @Temperatura,
    @Umidita,
    @Pressione
);
";
            using var connection = new MySqlConnection(_connectionString);

            connection.Execute(query, alarm);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE FROM warning_setting
WHERE
    id_silos = @Id;
";
            using var connection = new MySqlConnection(_connectionString);

            connection.Execute(query, new { id });
        }

    }
}
