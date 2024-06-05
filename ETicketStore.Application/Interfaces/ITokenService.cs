using ETicketStore.Application.Models;
using ETicketStore.Domain.Models;

namespace ETicketStore.Api.Admin.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
