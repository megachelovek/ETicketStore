using System;

namespace ETicketStore.Common.Models
{
    public class EventShedule : Event
    {
        public EventShedule(){}

        public EventShedule(Guid id, string title, string description, int amountTickets, DateTime eventDateTime, bool isPublic) : base(id, title, description, amountTickets, isPublic)
        {
            EventDateTime = eventDateTime;
        }

        public DateTime EventDateTime { get; set; }
    }
}
