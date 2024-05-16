using ETicketStore.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ETicketStore.Common.Queries
{
    public class EventQueries
    {
        public static string GetTicketsEvents(IEnumerable<string> tickets) => $"SELECT t.id as ticketId, c.* FROM public.{nameof(Event)} as c" +
            $"\r\nLEFT JOIN public.{nameof(Ticket)} as t ON t.event = c.id \r\nWHERE t.id IN (\'{tickets.First()}\' {string.Join(" ", tickets.Skip(0).ToList().Select(x => $",\'{x}\'"))})";

        public static string GetEventShedule() => $"SELECT t.eventdatetime as edate, c.* FROM public.{nameof(Event)} as c LEFT JOIN public.{nameof(Ticket)} as t ON t.{nameof(Event)} = c.id ORDER BY edate";

        public static string AddEventShedule(Event @event) => $"INSERT INTO public.{nameof(Event)} (id, title, description, amounttickets, ispublic) VALUES ('{@event.Id.ToString() ?? Guid.NewGuid().ToString()}','{@event.Title}','{@event.Description}','{@event.AmountTickets}',false)";
    }
}
