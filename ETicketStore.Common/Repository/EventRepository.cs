using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETicketStore.Common.Queries;
using ETicketStore.Common.Models;

namespace ETicketStore.Common.Repository
{
    public class EventRepository : Repository<Event>
    {       
        public EventRepository(IConfiguration configuration):base(configuration) {}

        public async Task<Dictionary<string, Event>> GetTicketsEvents(IEnumerable<string> tickets)
        {
            var conn = await GetConnection();
            var cmd = new NpgsqlCommand(EventQueries.GetTicketsEvents(tickets), conn);
            var reader = await cmd.ExecuteReaderAsync();
            var ticketEvents = new Dictionary<string, Event>();
            while (await reader.ReadAsync())
            {
                var @event = new Event(
                    Guid.Parse(reader["id"].ToString()),
                    reader["title"].ToString(),
                    reader["description"].ToString(),
                    (int)reader["amounttickets"],
                    (bool)reader["ispublic"]);

                ticketEvents.Add(reader["ticketId"].ToString(), @event);
            }

            return ticketEvents;
        }

        public async Task<List<EventShedule>> GetEventShedule()
        {
            var conn = await GetConnection();
            var cmd = new NpgsqlCommand(EventQueries.GetEventShedule(), conn);
            var reader = await cmd.ExecuteReaderAsync();
            var ticketEvents = new List<EventShedule>();
            while (await reader.ReadAsync())
            {
                var @event = new EventShedule(
                    Guid.Parse(reader["id"].ToString()),
                    reader["title"].ToString(),
                    reader["description"].ToString(),
                    (int)reader["amounttickets"],
                    DateTime.Parse(reader["edate"].ToString()),
                    (bool)reader["ispublic"]);

                ticketEvents.Add(@event);
            }

            return ticketEvents;
        }

        public async Task AddEventShedule(Event @event)
        {
            var conn = await GetConnection();
            var cmd = new NpgsqlCommand(EventQueries.AddEventShedule(@event), conn);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
