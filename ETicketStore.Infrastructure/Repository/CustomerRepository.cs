using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETicketStore.Domain.Queries;
using System.Linq;
using ETicketStore.Domain.Models;
using ETicketStore.Infrastructure.Data;
using Dapper;

namespace ETicketStore.Domain.Repository
{
    public class CustomerRepository:Repository<Customer>
    {
        private DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetTicketsCustomers(IEnumerable<string> tickets)
        {
            var connection = _context.CreateConnection();

            var customer = (await connection.QueryAsync<Customer>(CommonQueries.SelectAll(nameof(Customer)))).ToList();

            return customer;

        }
    }
}
