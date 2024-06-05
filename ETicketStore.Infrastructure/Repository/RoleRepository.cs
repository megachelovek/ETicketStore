using Dapper;
using ETicketStore.Domain.Models;
using ETicketStore.Domain.Queries;
using ETicketStore.Infrastructure.Data;

namespace ETicketStore.Domain.Repository
{
    public class RoleRepository : Repository<Role>
    {
        private DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var connection = _context.CreateConnection();

            var roles = (await connection.QueryAsync<Role>(CommonQueries.SelectAll(nameof(Role)))).ToList();

            return roles;
        }
    }
}
