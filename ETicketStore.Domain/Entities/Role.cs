using System.ComponentModel.DataAnnotations;

namespace ETicketStore.Domain.Models
{
    public class Role : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
