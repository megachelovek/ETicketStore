using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace ETicketStore.Infrastructure.Data
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetRequiredSection("PostgreSQL:ConnectionString");
            return new NpgsqlConnection(connectionString.Value);
        }

        //protected async Task<NpgsqlConnection> GetConnection()
        //{
        //    connection = _dataSource.CreateConnection();
        //    await connection.OpenAsync();
        //    return connection;
        //}

        //public void Dispose()
        //{
        //    connection.Close();
        //    IDisposable d = connection as IDisposable;
        //    if (d != null)
        //        d.Dispose();
        //    GC.SuppressFinalize(this);
        //}

        //public DbSet<User> Users { get; set; }
    }
}
