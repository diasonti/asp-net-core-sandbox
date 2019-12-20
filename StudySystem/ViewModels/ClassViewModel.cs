using System.ComponentModel.DataAnnotations;
using StudySystem.Validation;

namespace StudySystem.ViewModels
{
    public class ClassViewModel : BaseViewModel
    {
        [Required, StringLength(255)]
        public string Topic { get; set; }
        
        [CourseId]
        public long CourseId { get; set; }
    }
}
