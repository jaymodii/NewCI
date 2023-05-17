using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Entities.ViewModels
{
    public class SessionViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Avatar { get; set; }
        public SessionViewModel(long id, string name, string? avatar)
        {
            Id = id;
            Name = name;

            Avatar = avatar;

        }
    }
}
