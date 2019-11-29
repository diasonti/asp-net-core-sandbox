using System.ComponentModel.DataAnnotations;
using System.Linq;
using StudySystem.Data;

namespace StudySystem.Validation
{
    public class ClassId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (SandboxDbContext) validationContext.GetService(typeof(SandboxDbContext));
            var classId = (long) value;

            if (!dbContext.Classes.Any(c => c.Id.Equals(classId)))
            {
                return new ValidationResult($"No class found with id {classId}");
            }
            
            return ValidationResult.Success;
        }
    }
}
