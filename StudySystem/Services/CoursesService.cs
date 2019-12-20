using System.Collections.Generic;
using System.Linq;
using StudySystem.Models;
using StudySystem.Repositories.Interfaces;
using StudySystem.Services.Interfaces;
using StudySystem.ViewModels;

namespace StudySystem.Services
{
    public class CoursesService : ICoursesService
    {

        private readonly AbstractCourseRepository _courseRepository;
        private readonly AbstractUserAccountRepository _userAccountRepository;

        public CoursesService(AbstractCourseRepository courseRepository, AbstractUserAccountRepository userAccountRepository)
        {
            _courseRepository = courseRepository;
            _userAccountRepository = userAccountRepository;
        }

        public CourseViewModel ToViewModel(Course entity)
        {
            return new CourseViewModel
            {
                Id = entity.Id,
                Title = entity.Title
            };
        }

        public Course ToEntity(CourseViewModel viewModel)
        {
            return new Course
            {
                Id = viewModel.Id,
                Title = viewModel.Title
            };
        }

        public List<CourseViewModel> GetAllViewModels()
        {
            return _courseRepository.FindAll().Select(ToViewModel).ToList();
        }

        public CourseViewModel GetViewModel(long courseId)
        {
            return ToViewModel(_courseRepository.Find(courseId));
        }

        public void Save(CourseViewModel viewModel)
        {
            _courseRepository.Save(ToEntity(viewModel));
        }

        public void Remove(long courseId)
        {
            _courseRepository.Remove(courseId);
        }

        public List<CourseViewModel> getCoursesByStudentId(long studentId)
        {
            return _userAccountRepository.Find(studentId).CourseLinks.Select(link => ToViewModel(link.Course)).ToList();
        }
    }
}
