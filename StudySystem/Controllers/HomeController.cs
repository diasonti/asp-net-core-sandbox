using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudySystem.Models;
using StudySystem.Services.Interfaces;
using StudySystem.ViewModels;

namespace StudySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersService _usersService;
        private readonly ICoursesService _coursesService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, IUsersService usersService, ICoursesService coursesService, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _usersService = usersService;
            _signInManager = signInManager;
            _coursesService = coursesService;
        }


        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("ADMIN"))
                {
                    return RedirectToAction(nameof(Admin));
                }
                else
                {
                    return RedirectToAction(nameof(Student));
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles="ADMIN")]
        public IActionResult Admin()
        {
            ViewData["Users"] = _usersService.GetAllViewModels();
            ViewData["Courses"] = _coursesService.GetAllViewModels();
            
            return View("AdminHome");
        }
        
        [Authorize(Roles="STUDENT")]
        public IActionResult Student()
        {
            var user = _usersService.GetViewModelByUserName(User.Identity.Name);
            ViewData["User"] = user;
            ViewData["Courses"] = _coursesService.getCoursesByStudentId(user.Id.Value);
            return View("StudentHome");
        }
    }
}
