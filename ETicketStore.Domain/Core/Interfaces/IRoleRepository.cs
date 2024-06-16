using ETicketStore.Domain.Models;

namespace ETicketStore.Domain.Core.Interfaces
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetAllRoles();
    }
}
