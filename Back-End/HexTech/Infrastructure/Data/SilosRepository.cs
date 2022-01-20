
using ApplicationCore.Interfaces.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataSimulator.Interface.Service;
using DataSimulator.Entity;
using DataSimulator.Interfaces.Entities;
using ApplicationCore.Interfaces.Service;

namespace Infrastructure.Data
{
    public class SilosRepository : ISilosRepository
    {
        private readonly string _connectionString;

        private readonly IDataGenerator _dataGenerator;
        

        public SilosRepository(IConfiguration configuration, IDataGenerator dataGenerator)
        {
            _connectionString = configuration.GetConnectionString("hextech");
            _dataGenerator = dataGenerator;
        }

        public IEnumerable<ISilos> GetData()
        {

            const string query = @"
SELECT
    data,
    Id_Silos as IdSilos,
    level as livello,
    pressure as pressione,
    humidity as umidita,
    temperature as temperatura,
    control
FROM
    measurements;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.Query<Silos>(query);
        }

        public ISilos GetById(int id)
        {
            const string query = @"
SELECT
    data,
    Id_Silos as IdSilos,
    level as livello,
    pressure as pressione,
    humidity as umidita,
    temperature as temperatura,
    control
FROM
    measurements
WHERE
    id_silos = @id
ORDER BY
    id_measurements DESC;
";
            using var connection = new MySqlConnection(_connectionString);

            return connection.QueryFirstOrDefault<Silos>(query, new { id });
        }

        public void Insert(ISilos model)
        {
            model = _dataGenerator.getData(model);

            const string query = @"
INSERT INTO measurements(
    Level,
    Humidity,
    Temperature,
    Pressure,
    Data,
    Id_silos,
    Control)
VALUES(
    @Livello,
    @Umidita,
    @Temperatura,
    @Pressione,
    @data,
    @IdSilos,
    @Control
);
";
            using var connection = new MySqlConnection(_connectionString);

            connection.Execute(query, model);

        }

        
    }
}
