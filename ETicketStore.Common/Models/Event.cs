using System;
using System.Collections.Generic;

namespace ETicketStore.Common.Models
{
    public class Event
    {
        public Event(){}

        public Event(Guid id, string title, string description, int amountTickets, bool isPublic)
        {
            Id = id;
            Title = title;
            Description = description;
            AmountTickets = amountTickets;
            IsPublic = isPublic;
        }

        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AmountTickets { get; set; }
        public bool IsPublic { get; set; }
    }
}
