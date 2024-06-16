using Dapper;
using ETicketStore.Domain.Core.Interfaces;
using ETicketStore.Domain.Models;
using ETicketStore.Domain.Queries;
using ETicketStore.Infrastructure.Data;
using ETicketStore.Infrastructure.Repository;

namespace ETicketStore.Domain.Repository
{
    public class RoleRepository : BaseRepositoryAsync<Role>, IRoleRepository
    {
        private DataContext _context;

        public RoleRepository(DataContext context):base(context) 
        {
            _context = context;
        }

        public override Task<Role> AddAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var unitOfWork = _context.UnitOfWork;
            var action = unitOfWork.Connection;
            return (await action.QueryAsync<Role>(CommonQueries.SelectAll(nameof(Role)))).ToList();
        }

        public override void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
