
using NewCI.Entities.DTOs;
using NewCI.Entities.Models;
using NewCI.Entities.ViewModels;
using NewCI.Interfaces.RepositoryInterfaces;
using NewCI.Interfaces.ServiceInterfaces;
using NewCI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Business.Services
{
    public class UserService:GenericService<User> , IUserService
    {
 
        private readonly IUserInterface _userInterface;
        public UserService(IUserInterface userInterface) :base(userInterface)
        {
           
            _userInterface = userInterface; 
        }

        public SessionDto? Login(LoginPageViewModel obj)
        {
            if (obj == null)
            {
                return null;
            }

            CredentialDto credentials=new CredentialDto(obj.Email, obj.Password);
            
            return _userInterface.Login(credentials);

        }

      
    }
}
