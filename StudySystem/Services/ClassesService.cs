using System.Collections.Generic;
using System.Linq;
using StudySystem.Models;
using StudySystem.Repositories.Interfaces;
using StudySystem.Services.Interfaces;
using StudySystem.ViewModels;

namespace StudySystem.Services
{
    public class ClassesService : IClassesService
    {

        private readonly AbstractCourseRepository _courseRepository;
        private readonly AbstractClassRepository _classRepository;

        public ClassesService(AbstractCourseRepository courseRepository, AbstractClassRepository classRepository)
        {
            _courseRepository = courseRepository;
            _classRepository = classRepository;
        }

        public ClassViewModel ToViewModel(Class entity)
        {
            return new ClassViewModel
            {
                Id = entity.Id,
                Topic = entity.Topic,
                CourseId = entity.CourseId
            };
        }

        public Class ToEntity(ClassViewModel viewModel)
        {
            return new Class
            {
                Id = viewModel.Id,
                Topic = viewModel.Topic,
                CourseId = viewModel.CourseId
            };
        }

        public List<ClassViewModel> GetAllViewModels()
        {
            return _classRepository.FindAll().Select(ToViewModel).ToList();
        }

        public ClassViewModel GetViewModel(long classId)
        {
            return ToViewModel(_classRepository.FindWithTasks(classId));
        }

        public void Save(ClassViewModel viewModel)
        {
            _classRepository.Save(ToEntity(viewModel));
        }

        public void Remove(long classId)
        {
            _classRepository.Remove(classId);
        }

        public List<ClassViewModel> GetViewModelsByCourseId(long courseId)
        {
            return _courseRepository.Find(courseId).Classes.Select(ToViewModel).ToList();
        }
    }
}
