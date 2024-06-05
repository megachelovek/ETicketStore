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
using Microsoft.Extensions.Logging;

namespace ETicketStore.Domain.Repository
{
    public class ETicketRepository : Repository<Ticket>
    {
        private CustomerRepository _customerRepository;
        private EventRepository _eventRepository;
        private DataContext _context;

        public ETicketRepository(DataContext context, CustomerRepository customerRepository, EventRepository eventRepository) : base(configuration)
        {
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _context = context;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            var connection = _context.CreateConnection();

            var tickets = (await connection.QueryAsync<Ticket>(CommonQueries.SelectAll(nameof(Ticket)))).ToList();

            var customerIds = tickets.Select(t => t.CustomerId).ToList();
            var ticketsCustomers = await _customerRepository.GetTicketsCustomers(customerIds);

            var eventIds = tickets.Select(t => t.EventId).ToList();
            var ticketsEvents = await _eventRepository.GetTicketsEvents(eventIds);

            foreach (var ticket in tickets)
            {
                ticket.Customer = ticketsCustomers.FirstOrDefault(x => x.Id == Guid.Parse(ticket.CustomerId));
                ticket.Event = ticketsEvents.FirstOrDefault(x => x.Id == Guid.Parse(ticket.CustomerId));
            }

            return tickets;

        }

        public async Task BuyTicket(string customerId, string ticketId)
        {
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(TicketQueries.BuyTicket(customerId, ticketId));
        }
    }
}
