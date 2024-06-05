using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace ETicketStore.Domain.Repository
{
    public abstract class Repository<T> : IDisposable
        where T : class
    {
        
    }
}
