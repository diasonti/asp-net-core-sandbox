using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudySystem.Data;

namespace StudySystem.Models
{
    [Table("user_account_to_course_link")]
    public class UserAccountToCourseLink : IValidatableObject
    {
        [Column("user_account_id")]
        [ForeignKey("UserAccount")]
        [Required]
        public long UserAccountId { get; set; }

        public UserAccount UserAccount { get; set; }
        
        [Column("course_id")]
        [ForeignKey("Course")]
        [Required]
        public long CourseId { get; set; }
        
        public Course Course { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dbContext = (SandboxDbContext) validationContext.GetService(typeof(SandboxDbContext));

            var student = dbContext.UserAccounts.Include(s => s.CourseLinks).First(ua => ua.Id.Equals(UserAccountId));
            var validStudent = true;
            var validCourse = true;

            var results = new List<ValidationResult>();
            if (student == null || !student.Role.Equals("STUDENT"))
            {
                validStudent = false;
                results.Add(new ValidationResult($"No student found with id {UserAccountId}", new[] {"UserAccountId"}));
            }
            
            if (!dbContext.Courses.Any(c => c.Id.Equals(CourseId)))
            {
                validCourse = false;
                results.Add(new ValidationResult($"No course found with id {UserAccountId}", new[] {"UserAccountId"}));
            }
            
            if (validStudent && validCourse && student.CourseLinks.Any(l => l.CourseId == CourseId))
            {
                results.Add(new ValidationResult($"The student is already linked to the course", new[] {"CourseId"}));
            }

            return results;
        }
    }
}
