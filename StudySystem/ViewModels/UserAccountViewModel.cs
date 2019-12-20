using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using StudySystem.Validation;

namespace StudySystem.ViewModels
{
    public class UserAccountViewModel : BaseViewModel
    {
        [Required, StringLength(255)]
        public string Username { get; set; }

        [Required, UserRole]
        public string Role { get; set; }
        
    }
}
