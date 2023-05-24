




using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCI.Entities.DTOs;
using NewCI.Entities.ViewModels;

using NewCI.Interfaces.ServiceInterfaces;


namespace CIPlatform.Controllers.Users
{

    public class UserController : Controller
    {

        public readonly IUserService _IUser;
        public readonly IBannerService _IBanner;


        public UserController(IUserService userService, IBannerService banner)
        {
            _IUser = userService;
            _IBanner = banner;
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult LoginPage()
        {
            HttpContext.Session.Clear();
            BannersDto? data =  _IBanner.GetBanners();

            LoginPageViewModel viewModel = new LoginPageViewModel()
            {
                BannerList = data!.Banners
            };


            return View(viewModel);
        }
        [HttpPost]
        public IActionResult LoginPage(LoginPageViewModel obj)
        {
            if (ModelState.IsValid)
            {
                SessionDto? user = _IUser.Login(obj);
                if (user == null)
                {
                    TempData["error"] = "Invalid User or Password";
                    return RedirectToAction("LoginPage");
                }


                //Session Management
                HttpContext.Session.SetString("username", user.Name);
                HttpContext.Session.SetString("userId", user.Id.ToString());
                if (user.Avatar != null)
                {

                    HttpContext.Session.SetString("avatar", user.Avatar);
                }




                if (user.Role == "user")
                {
                    TempData["success"] = "Welcome to CI-Platform";
                    return RedirectToAction("LandingPage", "Landing");

                }
                else if (user.Role == "admin")
                {
                    TempData["success"] = 
                        
                            "Successfully Authenticated!! \n Welcome to Admin Screen !!"
                         ;
                    return RedirectToAction("SkillsPage", "Skill");
                }
                else
                {
                    TempData["info"] = "Contact to Developer";
                    return View();
                }
            }
            else
            {

                TempData["info"] = "Please enter valid credentials.";
                return View();
            }
        }
    }
}
