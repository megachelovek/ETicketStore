using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ETicketStore.Common.Repository
{
    public abstract class Repository<T> 
        where T : class
    {
        protected readonly NpgsqlDataSource _dataSource;

        protected Repository(IConfiguration configuration) {
            var connectionString = configuration.GetRequiredSection("PostgreSQL:ConnectionString");
            var dataSourceBuilder = new NpgsqlSlimDataSourceBuilder(connectionString.Value);
            _dataSource = dataSourceBuilder.Build();
        }
    }
}
