using System.Collections.Generic;
using StudySystem.Models;
using StudySystem.ViewModels;

namespace StudySystem.Services.Interfaces
{
    public interface ITasksService
    {
        TaskViewModel ToViewModel(Task entity);
        
        Task ToEntity(TaskViewModel viewModel);
        
        TaskViewModel ToIndTaskViewModel(IndividualTask entity);

        IndividualTask ToIndTaskEntity(TaskViewModel viewModel);
        
        List<TaskViewModel> GetAllViewModels();
        TaskViewModel GetViewModel(long id);

        void Save(TaskViewModel viewModel);
        
        void Remove(long id);
        
        
    }
}
