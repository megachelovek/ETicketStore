using ETicketStore.Domain.Models;

namespace ETicketStore.Domain.Core.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsers();
    }
}
