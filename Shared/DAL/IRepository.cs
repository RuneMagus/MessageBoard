using System.Collections.Generic;

namespace Shared
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> FetchAll();

        void Add(TEntity entity);
    }
}
