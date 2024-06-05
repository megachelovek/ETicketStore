using ETicketStore.Domain.Models;

namespace ETicketStore.Application.Models
{
    public  class Login : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
