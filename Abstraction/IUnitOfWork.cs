using System;

namespace Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        IPropertyDataAccess Properties { get; }
    }
}