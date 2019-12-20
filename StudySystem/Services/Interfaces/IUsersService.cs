using System.Collections.Generic;
using StudySystem.Models;
using StudySystem.ViewModels;

namespace StudySystem.Services.Interfaces
{
    public interface IUsersService
    {
        UserAccountViewModel ToViewModel(UserAccount entity);
        
        UserAccount ToEntity(UserAccountViewModel viewModel);
        
        List<UserAccountViewModel> GetAllViewModels();
        UserAccountViewModel GetViewModel(long id);

        void Save(UserAccountViewModel viewModel);
        
        void Remove(long id);
        UserAccountViewModel GetViewModelByUserName(string username);
    }
}
