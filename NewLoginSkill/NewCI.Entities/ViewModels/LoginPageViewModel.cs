using System;
using System.Collections.Generic;
using NewCI.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewCI.Entities.ViewModels
{
    public class LoginPageViewModel
    {
        [Required(ErrorMessage = "Please Enter registered Email ")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Please Enter your password.")]
        public string Password { get; set; } = null!;

        public List<Banner>? BannerList { get; set; }
    }
}
