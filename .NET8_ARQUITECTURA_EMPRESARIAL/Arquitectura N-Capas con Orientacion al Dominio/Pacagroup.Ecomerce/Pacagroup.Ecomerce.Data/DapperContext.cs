
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Pacagroup.Ecomerce.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("NortwindConnection")
                               ?? throw new ArgumentNullException(nameof(configuration), "Connection string 'SqlConnection' not found in configuration.");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
