using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETicketStore.Common.Queries;
using System.Linq;
using ETicketStore.Common.Models;

namespace ETicketStore.Common.Repository
{
    public class CustomerRepository : Repository<Customer>
    {       
        public CustomerRepository(IConfiguration configuration):base(configuration) {}

        public async Task<Dictionary<string, Customer>> GetTicketsCustomers(IEnumerable<string> tickets)
        {
            var conn = await GetConnection();
            var cmd = new NpgsqlCommand(CustomerQueries.GetTicketsCustomers(tickets), conn);
            var reader = await cmd.ExecuteReaderAsync();
            var ticketCustomers = new Dictionary<string, Customer>();
            while (await reader.ReadAsync())
            {
                var customer = new Customer(
                    Guid.Parse(reader["id"].ToString()),
                    reader["name"].ToString(),
                    reader["email"].ToString(),
                    reader["address"].ToString(),
                    reader["city"].ToString(),
                    reader["postalcode"].ToString(),
                    reader["country"].ToString(),
                    reader["phone"].ToString()
                );

                ticketCustomers.Add(reader["ticketId"].ToString(), customer);
            }

            return ticketCustomers;
        }
    }
}
