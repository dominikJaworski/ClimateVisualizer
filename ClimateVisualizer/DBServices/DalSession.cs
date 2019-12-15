using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ClimateVisualizer.DBServices
{
    public sealed class DalSession : IDisposable
    {
        public DalSession(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            string connectionString = configuration["Database:ConnectionString"];

            Connection = new SqlConnection(connectionString);

            Connection.Open();           
        }

        public SqlConnection Connection { get; private set; }

        // FUTURE: Add a unit of work

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
