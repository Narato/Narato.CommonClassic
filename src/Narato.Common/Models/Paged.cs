using System.Collections.Generic;
using System.Linq;

namespace Narato.Common.Models
{
    public class Paged<T> : IPaged<T>
    {
        public Paged(IEnumerable<T> source, int page, int pageSize, int totalCount)
        {
            Items = source;
            Skip = (page - 1) * pageSize;
            Take = source.Count();
            Total = totalCount;
        }

        public IEnumerable<T> Items { get; }
        public int Skip { get; }
        public int Take { get; }
        public int Total { get; }
    }
}
