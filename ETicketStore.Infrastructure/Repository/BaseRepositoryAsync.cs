using Dapper;
using ETicketStore.Domain;
using ETicketStore.Domain.Core;
using ETicketStore.Domain.Models;
using ETicketStore.Domain.Queries;
using ETicketStore.Infrastructure.Data;

namespace ETicketStore.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly DataContext _dbContext;

        public BaseRepositoryAsync(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            var connection = _dbContext.CreateConnection();
            return (await connection.QueryAsync<T>(CommonQueries.SelectItem(nameof(T), id.ToString()))).FirstOrDefault();
        }

        public async Task<IList<T>> ListAllAsync()
        {
            var connection = _dbContext.CreateConnection();
            return (await connection.QueryAsync<T>(CommonQueries.SelectAll(nameof(T)))).ToList();
        }

        public async Task<int> CountAsync(string tableName)
        {
            var connection = _dbContext.CreateConnection();
            return (await connection.QueryAsync<int>(CommonQueries.CountAsync(tableName))).FirstOrDefault();
        }

        public async Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
