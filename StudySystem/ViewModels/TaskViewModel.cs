using System.ComponentModel.DataAnnotations;
using StudySystem.Validation;

namespace StudySystem.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        [Required, StringLength(10000), DataType(DataType.MultilineText)]
        public string Text { get; set; }
        
        [Required, ClassId]
        public long ClassId { get; set; }
        
        public long? StudentId { get; set; }
    }
}
