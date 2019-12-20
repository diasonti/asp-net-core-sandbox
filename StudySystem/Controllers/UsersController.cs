using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudySystem.Data;
using StudySystem.Services;
using StudySystem.Services.Interfaces;
using StudySystem.ViewModels;

namespace StudySystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        // GE
        public IActionResult Create()
        {
            return View("Edit");
        }
        
        public IActionResult Edit(long id)
        {
            return View("Edit", _usersService.GetViewModel(id));
        }
        
        [HttpPost]
        public IActionResult Edit([Bind("Id,Username,Password,Role")] UserAccountViewModel form)
        {
            if (ModelState.IsValid)
            {
                _usersService.Save(form);
                return RedirectToAction("Admin", "Home");
            }
            return View("Edit", form);
        }

        public IActionResult Remove(long id)
        {
            _usersService.Remove(id);
            return RedirectToAction("Admin", "Home");
        }
    }
}
