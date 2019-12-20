using System.Collections.Generic;
using StudySystem.Models;
using StudySystem.ViewModels;

namespace StudySystem.Services.Interfaces
{
    public interface IClassesService : IViewModelService<Class, ClassViewModel>
    {
        List<ClassViewModel> GetViewModelsByCourseId(long courseId);
    }
}
