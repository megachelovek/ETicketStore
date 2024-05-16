using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace ETicketStore.Common.Repository
{
    public abstract class Repository<T> : IDisposable
        where T : class
    {
        protected readonly NpgsqlDataSource _dataSource;
        private readonly NpgsqlConnection connection;

        protected Repository(IConfiguration configuration)
        {
            var connectionString = configuration.GetRequiredSection("PostgreSQL:ConnectionString");
            var dataSourceBuilder = new NpgsqlSlimDataSourceBuilder(connectionString.Value);
            _dataSource = dataSourceBuilder.Build();
        }

        protected async Task<NpgsqlConnection> GetConnection()
        {
            
            var conn = await GetConnection();
            return conn;
        }

        public void Dispose()
        {
            connection.Close();
            IDisposable d = connection as IDisposable;
            if (d != null)
                d.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
