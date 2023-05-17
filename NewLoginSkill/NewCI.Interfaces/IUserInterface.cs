
using NewCI.Entities.Models;
using NewCI.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CI.Repositories.Interface
{
    public interface IUserInterface
    {
      
        public SessionViewModel? Login(LoginPageViewModel obj);
       
        public User GetUser(string email);
       
        public LoginPageViewModel? GetBanners();
    }
}
