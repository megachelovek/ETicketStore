using ETicketStore.Domain.Models;

namespace ETicketStore.Domain.Models
{
    public class UserDTO : BaseEntity
    {
        public UserDTO(int id, string email, string password, int roleId)
        {
            Id = id;
            Email = email;
            Password = password;
            RoleId = roleId;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
