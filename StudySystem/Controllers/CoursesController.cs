using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudySystem.Controllers
{
    public class CoursesController : Controller
    {
        
        [Authorize(Roles="ADMIN")]
        public IActionResult Create()
        {
            throw new System.NotImplementedException();
        }

        [Authorize(Roles="ADMIN")]
        public IActionResult Edit(long id)
        {
            throw new System.NotImplementedException();
        }

        [Authorize(Roles="ADMIN")]
        public IActionResult Remove(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
