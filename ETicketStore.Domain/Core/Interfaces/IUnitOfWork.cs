using ETicketStore.Domain.Models;
using System.Data;

namespace ETicketStore.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepositoryAsync<T> Repository<T>() where T : BaseEntity;
        public Guid Id { get; }
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; }
        public void Begin();
        public Task SaveChangesAsync();
        public Task RollBackChangesAsync();
    }
}
