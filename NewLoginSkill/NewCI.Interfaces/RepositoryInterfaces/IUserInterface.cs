using NewCI.Entities.DTOs;
using NewCI.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Interfaces.RepositoryInterfaces
{
    public interface IUserInterface : IGenericInterface<User>
    {
       
        public SessionDto? Login(CredentialDto obj);
      
      
       
       
   
    }

}
