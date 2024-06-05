using System.ComponentModel.DataAnnotations;

namespace ETicketStore.Domain.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
