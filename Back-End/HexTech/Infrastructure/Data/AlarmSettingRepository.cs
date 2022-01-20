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
    public class AlarmSettingRepository : IAlarmSettingRepository
    {
        private readonly string _connectionString;

        public AlarmSettingRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("hextech");
        }

        public IEnumerable<AlarmSetting> GetAlarms()
        {
            const string query = @"
SELECT
    Id,
    Id_Silos as IdSilos,
    temperature as temperatura,
    humidity as umidita,   
    pressure as pressione
FROM
    alarm_setting;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.Query<AlarmSetting>(query);
        }

        public AlarmSetting GetBySilosId(int id)
        {
            const string query = @"
SELECT
    Id,
    Id_Silos as IdSilos,
    temperature as temperatura,
    humidity as umidita,   
    pressure as pressione
FROM
    alarm_setting
WHERE
    id_silos = @id;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.QueryFirstOrDefault<AlarmSetting>(query, new { id });
        }

        public void Inser(AlarmSetting alarm)
        {
            const string query = @"
INSERT INTO alarm_setting(
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
DELETE FROM alarm_setting
WHERE
    id_silos = @Id;
";
            using var connection = new MySqlConnection(_connectionString);

            connection.Execute(query, new { id });
        }

    }
}
