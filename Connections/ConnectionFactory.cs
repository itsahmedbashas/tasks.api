using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;

namespace Tasks.API.Connections
{
    public class ConnFactory : IConnFactory
    {
        private readonly IConfiguration _config;

        public ConnFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection GetSqlConnection()
        {
            return new SqlConnection(_config.GetConnectionString("LearningConnection"));
        }
    }
}