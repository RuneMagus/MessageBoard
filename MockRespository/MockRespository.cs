using Shared;
using System.Collections.Generic;

namespace MockRespository
{
    public class MockRespository<T> : IRepository<T> where T : class
    {
        private readonly MockContext<T> context;

        public MockRespository(MockContext<T> context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.items.Add(entity);
        }

        public List<T> FetchAll()
        {
            return context.items;
        }
    }
}
