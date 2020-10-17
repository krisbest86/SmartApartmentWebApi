using System.Collections.Generic;

namespace Abstraction
{
    public interface IRepository<T, K>
        where T : class
    {
        T GetById(K id);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Add(T entity);

    }
}