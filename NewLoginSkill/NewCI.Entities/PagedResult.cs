using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Entities
{
    public class PagedResult<T>
    {
        public IEnumerable<T>? Entries { get; set; }
        public int TotalPages { get; set; }
    }

}
