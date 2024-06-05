using System;

namespace ETicketStore.Domain.Models
{
    public class EventSheduleDTO : EventDTO
    {
        public EventSheduleDTO(){}

        public EventSheduleDTO(Guid id, string title, string description, int amountTickets, DateTime eventDateTime, bool isPublic) : base(id, title, description, amountTickets, isPublic)
        {
            EventDateTime = eventDateTime;
        }

        public DateTime EventDateTime { get; set; }
    }
}
