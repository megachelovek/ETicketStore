using ETicketStore.Common.Models;
using System;

namespace ETicketStore.Common
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EventDateTime { get; set;}
        public string Place { get; set; }
        public Customer Customer { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
    }
}
