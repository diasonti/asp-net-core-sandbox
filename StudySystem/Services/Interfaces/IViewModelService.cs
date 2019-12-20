using System.Collections.Generic;
using StudySystem.Models;
using StudySystem.ViewModels;

namespace StudySystem.Services.Interfaces
{
    public interface IViewModelService<TEntity, TViewModel> where TEntity : BaseEntity where TViewModel : BaseViewModel
    {
        TViewModel ToViewModel(TEntity entity);
        
        TEntity ToEntity(TViewModel viewModel);
        
        List<TViewModel> GetAllViewModels();
        TViewModel GetViewModel(long id);

        void Save(TViewModel viewModel);
        
        void Remove(long id);
    }
}
