using ETicketStore.Domain.Queries;
using ETicketStore.Infrastructure.Data;
using Dapper;
using ETicketStore.Infrastructure.Repository;

namespace ETicketStore.Domain.Repository
{
    public class ETicketRepository : BaseRepositoryAsync<Ticket>
    {
        private CustomerRepository _customerRepository;
        private EventRepository _eventRepository;
        private DataContext _context;

        public ETicketRepository(DataContext context, CustomerRepository customerRepository, EventRepository eventRepository) : base(context)
        {
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
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

        public override Task<Ticket> AddAsync(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
