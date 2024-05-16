using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETicketStore.Common.Queries;
using System.Linq;

namespace ETicketStore.Common.Repository
{
    public class ETicketRepository : Repository<Ticket>
    {
        private CustomerRepository _customerRepository;
        private EventRepository _eventRepository;

        public ETicketRepository(IConfiguration configuration, CustomerRepository customerRepository, EventRepository eventRepository) : base(configuration)
        {
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            var conn = await GetConnection();
            var cmd = new NpgsqlCommand(CommonQueries.SelectAll(nameof(Ticket)), conn);
            var reader = await cmd.ExecuteReaderAsync();
            var result = new List<Ticket>();

            while (await reader.ReadAsync())
            {
                var ticket = new Ticket(
                    id: ((Guid)reader["id"]),
                    title: (string)reader["title"],
                    description: (string)reader["description"],
                    createdDate: (DateTime)reader["createddate"],
                    eventDateTime: (DateTime)reader["eventdatetime"],
                    row: (int)reader["row"],
                    column: (char)reader["column"],
                    customerId: reader["customer"] != DBNull.Value ? ((Guid)reader["customer"]).ToString() : "",
                    price: (decimal)reader["price"],
                    address: (string)reader["address"],
                    isAvailable: (bool)reader["isavailable"],
                    @eventId: ((Guid)reader["event"]).ToString());

                result.Add(ticket);
            }

            var tickets = result.Select(x => x.Id.ToString());
            var ticketsCustomers = await _customerRepository.GetTicketsCustomers(tickets);
            var ticketsEvents = await _eventRepository.GetTicketsEvents(tickets);

            foreach (var ticket in result)
            {
                ticket.Customer = ticketsCustomers.ContainsKey(ticket.Id.ToString()) ? ticketsCustomers[ticket.Id.ToString()] : null;
                ticket.Event = ticketsEvents[ticket.Id.ToString()] ?? null;
            }

            return result;
        }

        public async Task BuyTicket(string customerId, string ticketId)
        {
            var conn = await GetConnection();
            var cmd = new NpgsqlCommand(TicketQueries.BuyTicket(customerId, ticketId), conn);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
