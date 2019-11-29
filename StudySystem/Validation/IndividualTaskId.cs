using System.ComponentModel.DataAnnotations;
using System.Linq;
using StudySystem.Data;

namespace StudySystem.Validation
{
    public class IndividualTaskId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (SandboxDbContext) validationContext.GetService(typeof(SandboxDbContext));
            var taskId = (long) value;

            if (!dbContext.IndividualTasks.Any(c => c.Id.Equals(taskId)))
            {
                return new ValidationResult($"No individual task found with id {taskId}");
            }
            
            return ValidationResult.Success;
        }
    }
}
