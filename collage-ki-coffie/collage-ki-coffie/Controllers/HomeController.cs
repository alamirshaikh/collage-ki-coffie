using collage_ki_coffie.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace collage_ki_coffie.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

 
        public IActionResult Index()
        {

            return View();
        }
            
 
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


        public IActionResult Login(string userid,string password)
        {
            



                    if(userid == "coffie" && password=="chai")
                    {
                        //Create the identity for the user  
                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, userid)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("Index", "Home");
                 
                }
             
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
