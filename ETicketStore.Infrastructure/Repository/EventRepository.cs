using Microsoft.Extensions.Configuration;
using Npgsql;
using ETicketStore.Domain.Queries;
using ETicketStore.Domain.Models;
using ETicketStore.Infrastructure.Data;
using Dapper;

namespace ETicketStore.Domain.Repository
{
    public class EventRepository : Repository<Event>
    {
        private DataContext _context;

        public EventRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<List<Event>> GetTicketsEvents(IEnumerable<string> tickets)
        {
            var connection = _context.CreateConnection();

            var events = (await connection.QueryAsync<Event>(EventQueries.GetTicketsEvents(tickets))).ToList();

            return events;
        }

        public async Task<List<EventShedule>> GetEventShedule()
        {
            var connection = _context.CreateConnection();

            var eventsShedule = (await connection.QueryAsync<EventShedule>(EventQueries.GetEventShedule())).ToList();

            return eventsShedule;
        }

        public async Task AddEventShedule(Event @event)
        {
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(EventQueries.AddEventShedule(@event));
        }
    }
}
