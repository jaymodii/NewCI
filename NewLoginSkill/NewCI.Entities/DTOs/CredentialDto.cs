using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Entities.DTOs
{
    public class CredentialDto
    {

    
        public string Email { get; set; } = null!;
       
        public string Password { get; set; } = null!;

        public CredentialDto(string mail,string pass)
        {
            Email = mail;
            Password = pass;
           
        }
    }
}
