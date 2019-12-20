using Microsoft.AspNetCore.Mvc;
using StudySystem.Services.Interfaces;
using StudySystem.ViewModels;

namespace StudySystem.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClassesService _classesService;
        private readonly ICoursesService _coursesService;

        public ClassesController(IClassesService classesService, ICoursesService coursesService)
        {
            _classesService = classesService;
            _coursesService = coursesService;
        }

        public IActionResult List(long courseId)
        {
            ViewData["course"] = _coursesService.GetViewModel(courseId);
            ViewData["classes"] = _classesService.GetViewModelsByCourseId(courseId);
            return View();
        }
        
        public IActionResult Create()
        {
            return View("Edit");
        }
        
        public IActionResult Edit(long id)
        {
            return View("Edit", _classesService.GetViewModel(id));
        }
        
        [HttpPost]
        public IActionResult Edit([Bind("Id,Topic,CourseId")] ClassViewModel form)
        {
            if (ModelState.IsValid)
            {
                _classesService.Save(form);
                return RedirectToAction("Admin", "Home");
            }
            return View("Edit", form);
        }

        public IActionResult Remove(long id)
        {
            _classesService.Remove(id);
            return RedirectToAction("Admin", "Home");
        }
    }
}
