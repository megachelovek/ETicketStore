using ETicketStore.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ETicketStore.Common.Queries
{
    public class CustomerQueries
    {
        public static string GetTicketsCustomers(IEnumerable<string> tickets) => $"SELECT t.id as ticketId, c.* FROM public.{nameof(Customer)} as c" +
            $"\r\nLEFT JOIN public.{nameof(Ticket)} as t ON t.customer = c.id \r\nWHERE t.id IN (\'{tickets.First()}\' {string.Join(" ", tickets.Skip(0).ToList().Select(x => $",\'{x}\'"))})";
    }
}
