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
using ETicketStore.Infrastructure.Repository;

namespace ETicketStore.Domain.Repository
{
    public class CustomerRepository: BaseRepositoryAsync<Customer>
    {
        public CustomerRepository(DataContext context):base(context) 
        {}

        public async Task<List<Customer>> GetTicketsCustomers(IEnumerable<string> tickets)
        {
            var unitOfWork = _context.UnitOfWork;
            var action = unitOfWork.Connection;
            var customer = (await action.QueryAsync<Customer>(CommonQueries.SelectAll(nameof(Customer)))).ToList();

            return customer;
        }

        public override Task<Customer> AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }
         
        public override void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
