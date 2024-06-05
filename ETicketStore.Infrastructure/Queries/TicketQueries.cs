namespace ETicketStore.Domain.Queries
{
    public class TicketQueries
    {
        public static string BuyTicket(string cusomerId, string ticketId) => $"UPDATE public.{nameof(Ticket)} SET customer='{cusomerId}',isavailable = false WHERE Id = '{ticketId}'";
    }
}
