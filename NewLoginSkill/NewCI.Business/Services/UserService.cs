using NewCI.Entities.DTOs;
using NewCI.Entities.ViewModels;
using NewCI.Interfaces.ServiceInterfaces;
using NewCI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Business.Services
{
    public class UserService:IUserService
    {
        private readonly UserRepository _user;

        public UserService(UserRepository userRepository)
        {
            _user = userRepository;
        }

        public SessionDto? Login(LoginPageViewModel obj)
        {
            if (obj == null)
            {
                return null;
            }

            CredentialDto credentials=new CredentialDto(obj.Email, obj.Password);
            
            return _user.Login(credentials);

        }

        public BannersDto? GetBanners()
        {
           
            return _user.GetBanners();
        }
    }
}
