using System.ComponentModel.DataAnnotations;
using System.Linq;
using StudySystem.Data;

namespace StudySystem.Validation
{
    public class CourseId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (ApplicationDbContext) validationContext.GetService(typeof(ApplicationDbContext));
            var courseId = (long) value;

            if (!dbContext.Courses.Any(c => c.Id.Equals(courseId)))
            {
                return new ValidationResult($"No course found with id {courseId}");
            }
            
            return ValidationResult.Success;
        }
    }
}
