using ETicketStore.Domain.Models;
using ETicketStore.Domain.Queries;
using Dapper;
using ETicketStore.Infrastructure.Data;

namespace ETicketStore.Domain.Repository
{
    public class UserRepository : Repository<User>
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var connection = _context.CreateConnection();

            var users = (await connection.QueryAsync<User>(CommonQueries.SelectAll(nameof(User)))).ToList();

            return users;

        }
    }

}
