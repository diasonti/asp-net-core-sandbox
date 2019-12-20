using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudySystem.Services.Interfaces;
using StudySystem.ViewModels;

namespace StudySystem.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;
        private readonly IClassesService _classesService;

        public TasksController(ITasksService tasksService, IClassesService classesService)
        {
            _tasksService = tasksService;
            _classesService = classesService;
        }

        public IActionResult ListByClass(long classId)
        {
            List<TaskViewModel> tasks = _tasksService.GetByClassId(classId);
            ViewData["Tasks"] = tasks;
            ViewData["Class"] = _classesService.GetViewModel(classId);
            return View("List");
        }
        
        public IActionResult ListByCourse(long courseId)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Edit(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
