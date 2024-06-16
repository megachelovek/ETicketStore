using ETicketStore.Domain.Core.Interfaces;
using ETicketStore.Domain.Models;
using ETicketStore.Infrastructure.Repository;
using System.Data;

namespace ETicketStore.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly IDbConnection _connection = null;
        public readonly IDictionary<Type, dynamic> _repositories;
        public IDbTransaction _transaction;
        public readonly Guid _id = Guid.Empty;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _repositories = new Dictionary<Type, dynamic>();
        }

        public IBaseRepositoryAsync<T> Repository<T>() where T : BaseEntity
        {
            var entityType = typeof(T);

            if (_repositories.ContainsKey(entityType))
            {
                return _repositories[entityType];
            }

            var repositoryType = typeof(BaseRepositoryAsync<T>);

            var repository = (BaseRepositoryAsync<T>)Activator.CreateInstance(repositoryType, repositoryType.MakeGenericType(typeof(T)), _connection);

            if (repository == null)
            {
                throw new NullReferenceException("Repository should not be null");
            }

            _repositories.Add(entityType, repository);

            return (IBaseRepositoryAsync<T>)repository;
        }

        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public async Task SaveChangesAsync()
        {
            _transaction.Commit();
            Dispose();
        }

        public async Task RollBackChangesAsync()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();
            _transaction = null;
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public IDbTransaction Transaction
        {
            get { return _transaction; }
        }

        public Guid Id
        {
            get { return _id; }
        }


    }
}
