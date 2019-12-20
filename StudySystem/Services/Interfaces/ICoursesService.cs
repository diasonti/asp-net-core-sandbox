using System.Collections.Generic;
using StudySystem.Models;
using StudySystem.ViewModels;

namespace StudySystem.Services.Interfaces
{
    public interface ICoursesService : IViewModelService<Course, CourseViewModel>
    {
        List<CourseViewModel> getCoursesByStudentId(long studentId);
    }
}
