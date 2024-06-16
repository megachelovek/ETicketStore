using ETicketStore.Domain.Models;
using ETicketStore.Domain.Queries;
using Dapper;
using ETicketStore.Infrastructure.Data;
using ETicketStore.Infrastructure.Repository;

namespace ETicketStore.Domain.Repository
{
    public class UserRepository : BaseRepositoryAsync<User>
    {
        private DataContext _context;

        public UserRepository(DataContext context):base(context) 
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var unitOfWork = _context.UnitOfWork;
            var action = unitOfWork.Connection;
            var users = (await action.QueryAsync<User>(CommonQueries.SelectAll(nameof(User)))).ToList();

            return users;
        }

        public override Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(User entity)
        {
            throw new NotImplementedException();
        }        

        public override void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
