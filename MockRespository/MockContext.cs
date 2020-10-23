using System.Collections.Generic;

namespace MockRespository
{
    public class MockContext<T>
    {
        public readonly List<T> items;

        public MockContext()
        {
            items = new List<T>();
        }
    }
}
