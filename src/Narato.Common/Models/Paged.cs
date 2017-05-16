using System.Collections.Generic;

namespace Narato.Common.Models
{
    public class Paged<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int Total { get; set; }
    }
}
