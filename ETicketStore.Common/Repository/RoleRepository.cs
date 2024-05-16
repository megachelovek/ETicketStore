using ETicketStore.Common.Models;
using ETicketStore.Common.Queries;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicketStore.Common.Repository
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(IConfiguration configuration) : base(configuration)
        {}

        public async Task<List<Role>> GetAllRoles()
        {
            var conn = await GetConnection();
            var cmd = new NpgsqlCommand(CommonQueries.SelectAll(nameof(Role)), conn);
            var reader = await cmd.ExecuteReaderAsync();
            var users = new List<Role>();
            while (await reader.ReadAsync())
            {
                var user = new Role(
                    int.Parse(reader["id"].ToString()),
                    reader["name"].ToString());

                users.Add(user);
            }

            return users;
        }
    }
}
