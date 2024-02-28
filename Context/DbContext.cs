using System.Data;
using System.Data.SqlClient;

namespace Backend.Context
{
    public class DbContext
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = configuration.GetConnectionString("DefaultConnection");

        }

        public SqlConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
