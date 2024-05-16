using ETicketStore.Common.Models;
using ETicketStore.Common.Queries;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicketStore.Common.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {}

        public async Task<List<User>> GetAllUsers()
        {
            var conn = _dataSource.CreateConnection();
            await conn.OpenAsync();
            var cmd = new NpgsqlCommand(CommonQueries.SelectAll(nameof(User)), conn);
            var reader = await cmd.ExecuteReaderAsync();
            var users = new List<User>();
            while (await reader.ReadAsync())
            {
                var user = new User(
                    int.Parse(reader["id"].ToString()),
                    reader["email"].ToString(),
                    reader["password"].ToString(),
                    (int)reader["role"]);

                users.Add(user);
            }
            return users;

        }
    }

}
