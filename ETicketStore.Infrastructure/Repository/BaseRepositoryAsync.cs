using Dapper;
using ETicketStore.Domain.Core.Interfaces;
using ETicketStore.Domain.Models;
using ETicketStore.Domain.Queries;
using ETicketStore.Infrastructure.Data;

namespace ETicketStore.Infrastructure.Repository
{
    public abstract class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly DataContext _context;

        public BaseRepositoryAsync(DataContext dbContext)
        {
            _context = dbContext;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            var unitOfWork = _context.UnitOfWork;
            var action = unitOfWork.Connection;
            return (await action.QueryAsync<T>(CommonQueries.SelectItem(nameof(T), id.ToString()))).FirstOrDefault();
        }

        public async Task<IList<T>> ListAllAsync()
        {
            var unitOfWork = _context.UnitOfWork;
            var action = unitOfWork.Connection;
            return (await action.QueryAsync<T>(CommonQueries.SelectAll(nameof(T)))).ToList();
        }

        public async Task<int> CountAsync(string tableName)
        {
            var unitOfWork = _context.UnitOfWork;
            var action = unitOfWork.Connection;
            return (await action.QueryAsync<int>(CommonQueries.CountAsync(tableName))).FirstOrDefault();
        }

        public abstract Task<T> AddAsync(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(T entity);
    }
}
