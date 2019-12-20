using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using StudySystem.Data;
using StudySystem.Models;
using StudySystem.Repositories.Interfaces;
using StudySystem.Services.Interfaces;
using StudySystem.ViewModels;

namespace StudySystem.Services
{
    public class UsersService : IUsersService
    {
        private readonly AbstractUserAccountRepository _userAccountRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersService(AbstractUserAccountRepository userAccountRepository, UserManager<IdentityUser> userManager)
        {
            _userAccountRepository = userAccountRepository;
            this._userManager = userManager;
        }

        public List<UserAccountViewModel> GetAllViewModels()
        {
            return _userAccountRepository.FindAll().Select(ToViewModel).ToList();
        }

        public UserAccountViewModel GetViewModel(long userId)
        {
            return ToViewModel(_userAccountRepository.Find(userId));
        }
        
        public void Save(UserAccountViewModel viewModel)
        {
            _userAccountRepository.Save(ToEntity(viewModel));
        }

        public void Remove(long id)
        {
            _userAccountRepository.Remove(id);
        }

        public UserAccountViewModel GetViewModelByUserName(string username)
        {
            return ToViewModel(_userAccountRepository.FindByUsername(username));
        }

        public UserAccountViewModel ToViewModel(UserAccount entity)
        {
            return new UserAccountViewModel
            {
                Id = entity.Id,
                Username = entity.Username,
                Role = entity.Role
            };
        }

        public UserAccount ToEntity(UserAccountViewModel viewModel)
        {
            var entity = new UserAccount {Username = viewModel.Username, Role = viewModel.Role};
            if (viewModel.Id.HasValue)
                entity.Id = viewModel.Id.Value;
            return entity;
        }
    }
}
