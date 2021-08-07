using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeGymLive.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(T entity);

        Task<List<T>> GetAll();
    }
}
