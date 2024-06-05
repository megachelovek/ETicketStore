using System.ComponentModel.DataAnnotations;

namespace ETicketStore.Domain.Models
{
    public class Event : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AmountTickets { get; set; }
        public bool IsPublic { get; set; }
    }
}
