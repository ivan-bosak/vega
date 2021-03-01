using System.Collections.Generic;
using System.Threading.Tasks;

namespace vega.Core.Models
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }
}