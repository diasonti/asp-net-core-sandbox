using System.Collections.Generic;
using System.Linq;
using StudySystem.Models;
using StudySystem.Repositories.Interfaces;
using StudySystem.Services.Interfaces;
using StudySystem.ViewModels;

namespace StudySystem.Services
{
    public class TasksService : ITasksService
    {

        private readonly AbstractClassRepository _classRepository;

        public TasksService(AbstractClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public TaskViewModel ToViewModel(Task entity)
        {
            return new TaskViewModel
            {
                Id = entity.Id,
                Text = entity.Text,
                ClassId = entity.ClassId
            };
        }
        
        public TaskViewModel ToIndTaskViewModel(IndividualTask entity)
        {
            return new TaskViewModel
            {
                Id = entity.Id,
                Text = entity.Text,
                ClassId = entity.ClassId,
                StudentId = entity.StudentId
            };
        }

        public Task ToEntity(TaskViewModel viewModel)
        {
            return new Task
            {
                Id = viewModel.Id,
                Text = viewModel.Text,
                ClassId = viewModel.ClassId
            };
        }

        public IndividualTask ToIndTaskEntity(TaskViewModel viewModel)
        {
            return new IndividualTask
            {
                Id = viewModel.Id,
                Text = viewModel.Text,
                ClassId = viewModel.ClassId,
                StudentId = viewModel.StudentId.Value
            };
        }

        public List<TaskViewModel> GetAllViewModels()
        {
            var classes = _classRepository.FindAll();
            var viewModels = new List<TaskViewModel>();
            classes.ForEach(c =>
            {
                viewModels.AddRange(c.Tasks.Select(ToViewModel));
                viewModels.AddRange(c.IndividualTasks.Select(ToIndTaskViewModel));
            });
            return viewModels;
        }

        public TaskViewModel GetViewModel(long id)
        {
            return GetViewModel(id, false);
        }

        public TaskViewModel GetViewModel(long id, bool individual)
        {
            if (individual)
            {
                return ToIndTaskViewModel(_classRepository.FindByIndividualTaskIdWithTasks(id).IndividualTasks
                    .Single(t => t.Id.Equals(id)));
            }
            return ToViewModel(_classRepository.FindByTaskIdWithTasks(id).Tasks
                .Single(t => t.Id.Equals(id)));
        }

        public void Save(TaskViewModel viewModel)
        {
            var clazz = _classRepository.FindWithTasks(viewModel.ClassId);
            if (viewModel.StudentId.HasValue)
            {
                clazz.IndividualTasks.Add(ToIndTaskEntity(viewModel));
            }
            else
            {
                clazz.Tasks.Add(ToEntity(viewModel));   
            }
            _classRepository.Save(clazz);
        }

        public void Remove(long id)
        {
            Remove(id ,false);
        }
        public void Remove(long id, bool individual)
        {
            Class clazz;
            if (individual)
            {
                clazz =_classRepository.FindByIndividualTaskIdWithTasks(id);
                clazz.IndividualTasks.Remove(clazz.IndividualTasks.Single(t => t.Id.Equals(id)));
            }
            else
            {
                clazz =_classRepository.FindByTaskIdWithTasks(id);
                clazz.Tasks.Remove(clazz.Tasks.Single(t => t.Id.Equals(id)));
            }
            _classRepository.Save(clazz);
        }
    }
}
