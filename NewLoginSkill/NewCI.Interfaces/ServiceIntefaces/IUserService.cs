using NewCI.Entities.DTOs;
using NewCI.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {
         
              public  SessionDto? Login(LoginPageViewModel obj);
 
             public BannersDto? GetBanners();
           
        

    }
}
    