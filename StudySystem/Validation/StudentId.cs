using System.ComponentModel.DataAnnotations;
using System.Linq;
using StudySystem.Data;

namespace StudySystem.Validation
{
    public class StudentId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (SandboxDbContext) validationContext.GetService(typeof(SandboxDbContext));
            var studentId = (long) value;

            if (!dbContext.UserAccounts.Any(c => c.Id.Equals(studentId) && c.Role.Equals("STUDENT")))
            {
                return new ValidationResult($"No student found with id {studentId}");
            }
            
            return ValidationResult.Success;
        }
    }
}
