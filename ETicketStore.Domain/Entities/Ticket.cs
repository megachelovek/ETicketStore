using ETicketStore.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ETicketStore.Domain
{
    public class Ticket : BaseEntity
    {
        [Key]
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
        public bool IsAvailable { get; set; }
        public Event Event { get; set; }
        public string EventId { get; }
    }
}
