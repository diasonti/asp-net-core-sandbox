using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudySystem.Models;

namespace StudySystem.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticationController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login(string username, string password)
        {
            _signInManager.PasswordSignInAsync(username, password, true, false).Wait();
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
        
    }
}
