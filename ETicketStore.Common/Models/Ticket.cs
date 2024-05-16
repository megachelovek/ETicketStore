using ETicketStore.Common.Models;
using System;

namespace ETicketStore.Common
{
    public class Ticket
    {
        public Ticket(Guid id, string title, string description, DateTime createdDate, DateTime eventDateTime, int row, char column, string customerId, decimal price, string address, bool isAvailable, string @eventId)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedDate = createdDate;
            EventDateTime = eventDateTime;
            Row = row;
            Column = column;
            CustomerId = customerId;
            Price = price;
            Address = address;
            isavailable = isAvailable;
            EventId = @eventId;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EventDateTime { get; set;}
        public int Row { get; set; } // 1,2,3
        public char Column { get; set; } // a,b,c
        public Customer Customer { get; set; }
        public string CustomerId { get; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public bool isavailable { get; set; }
        public Event Event { get; set; }
        public string EventId { get; }
    }
}
