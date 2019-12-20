using System.ComponentModel.DataAnnotations;
using System.Linq;
using StudySystem.Data;

namespace StudySystem.Validation
{
    public class UserRole : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var input = (string) value;
            if (input.Equals("ADMIN") || input.Equals("STUDENT"))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"Role can be either 'ADMIN' or 'STUDENT'");
        }
    }
}
