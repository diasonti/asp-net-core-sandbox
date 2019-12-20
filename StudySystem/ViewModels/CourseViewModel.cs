using System.ComponentModel.DataAnnotations;

namespace StudySystem.ViewModels
{
    public class CourseViewModel : BaseViewModel
    {
        [Required, StringLength(1000)]
        public string Title { get; set; }
        
    }
}
