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
        private NpgsqlConnection connection;

        protected Repository(IConfiguration configuration)
        {
            var connectionString = configuration.GetRequiredSection("PostgreSQL:ConnectionString");
            var dataSourceBuilder = new NpgsqlSlimDataSourceBuilder(connectionString.Value);
            _dataSource = dataSourceBuilder.Build();
        }

        protected async Task<NpgsqlConnection> GetConnection()
        {
            connection = _dataSource.CreateConnection();
            await connection.OpenAsync();
            return connection;
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
