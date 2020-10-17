using Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RepositoryServices
{

    namespace Repository.Repository.Implementations
    {
        public class RepositoryEntityFramework<T, K> : IRepository<T, K>
            where T : class
            where K : struct
        {
            protected readonly DbContext Context;

            public RepositoryEntityFramework(DbContext context)
            {
                Context = context;
            }

            public IEnumerable<T> GetAll()
            {
                return Context.Set<T>();
            }

            public T GetById(K id)
            {
                return Context.Set<T>().Find(id);
            }

            public void Delete(T entity)
            {
                Context.Set<T>().Remove(entity);
            }

            public void Add(T entity)
            {
                Context.Set<T>().Add(entity);
            }

        }
    }

}
