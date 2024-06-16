using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace ETicketStore.Infrastructure.Data
{
    public sealed class DataContext : IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection = null;
        private readonly UnitOfWork _unitOfWork = null;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = CreateConnection();
            _connection.Open();
            _unitOfWork = new UnitOfWork(_connection);
        }

        private IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetRequiredSection("PostgreSQL:ConnectionString");
            return new NpgsqlConnection(connectionString.Value);
        }

        public UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _connection.Dispose();
        }
    }
}
