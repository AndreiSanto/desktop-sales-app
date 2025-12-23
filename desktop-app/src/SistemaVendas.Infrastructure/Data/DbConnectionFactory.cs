using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Infrastructure.Data
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection Create()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }

}
