using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Entities.DTOs
{
    public class SessionDto
    {
        public string Name { get; set; }
        public string? Avatar { get; set; }
        public string Role { get; set; }
        public long Id { get; set; }    
        public SessionDto( string name, string? avatar,string role,long id)
        {
          
            Name = name;
            Id= id;
            Avatar = avatar;
            Role = role;

        }
    }
}
