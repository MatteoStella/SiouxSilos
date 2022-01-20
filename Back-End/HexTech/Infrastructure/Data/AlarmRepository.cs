using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Infrastructure.Data
{
    public class AlarmRepository : IAlarmRepository
    {
        private readonly string _connectionString;

        public AlarmRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("hextech");
        }

        public IEnumerable<Alarm> GetAlarms()
        {
            const string query = @"
SELECT
    id_alarm_thresholds as Id,
    Id_Silos as IdSilos,
    level as livello,
    humidity as umidita,
    temperature as temperatura,
    pressure as pressione,
    description as descrizione
FROM
    alarm_thresholds;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.Query<Alarm>(query);
        }

        public Alarm GetById(int id)
        {
            const string query = @"
SELECT
    id_alarm_thresholds as Id,
    Id_Silos as IdSilos,
    level as livello,
    humidity as umidita,
    temperature as temperatura,
    pressure as pressione
FROM
    alarm_thresholds
WHERE
    id_alarm_thresholds = @id;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.QueryFirstOrDefault<Alarm>(query, new { id });
        }

        public void Inser(Alarm alarm)
        {
            const string query = @"
INSERT INTO alarm_thresholds(
    Id_Silos,
    level,
    humidity,
    temperature,
    pressure,
    description)
VALUES(
    @IdSilos,
    @Livello,
    @Umidita,
    @Temperatura,
    @Pressione,
    @Descrizione
);
";
            using var connection = new MySqlConnection(_connectionString);

            connection.Execute(query, alarm);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE FROM alarm_thresholds
WHERE id_alarm_thresholds = @id;";

            using var connection = new MySqlConnection(_connectionString);

            connection.Execute(query, new { id });
        }
    }
}
