using DtpontesStore.Core.DomainObjects;
using System;

namespace DtpontesStore.Core.Data
{
    public interface IRepository<T> : IDisposable where T :IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
