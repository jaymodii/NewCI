using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Entities.DTOs
{
    public class AdminScreenDto<T>
    {

        public int count { get; set; }
        public int? pagenumber { get; set; }
        public IEnumerable<T> records { get; set; }=new List<T>();
        public AdminScreenDto(IEnumerable<T> entries,int count,int pagenumber=1)
        {
            records = entries;
          this.count = count;
            this.pagenumber = pagenumber;
        }
        public AdminScreenDto() { }
    }
}
