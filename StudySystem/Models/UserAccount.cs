using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace StudySystem.Models
{
    [Table("user_account")]
    public class UserAccount : IValidatableObject
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("username")]
        [Required, StringLength(255)]
        public string Username { get; set; }
        
        [Column("password")]
        [Required, DataType(DataType.Password)]
        [Remote("ValidatePassword", "UserAccount")]
        public string Password { get; set; }
        
        [Column("role")]
        [Required]
        [Remote("ValidateRole", "UserAccount")]
        public string Role { get; set; }
        
        public ICollection<UserAccountToCourseLink> CourseLinks { get; set; }

        public ICollection<Course> Courses()
        {
            return CourseLinks.Select(link => link.Course).ToList();
        }

        public void addCourse(Course course)
        {
            if (!course.Id.HasValue || !this.Id.HasValue)
                return;
            if (CourseLinks.Any(link => link.CourseId == course.Id))
            {
                return;
            }
            CourseLinks.Add(new UserAccountToCourseLink(){Course = course, CourseId = course.Id.Value, UserAccount = this, UserAccountId = this.Id.Value});
        }
        
        public void removeCourse(Course course)
        {
            if (!course.Id.HasValue || !this.Id.HasValue)
                return;
            foreach (var link in CourseLinks)
            {
                if (link.CourseId == course.Id)
                {
                    CourseLinks.Remove(link);
                    return;
                }
            }
        }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Password.Length < 6)
            {
                results.Add(new ValidationResult("Password should be at least 6 symbols long", new[] {"Password"}));
            }
            else if (Password.Length > 255)
            {
                results.Add(new ValidationResult("Password should not be longer than 255 symbols", new[] {"Password"}));
            }
            else if (!Regex.Match(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$").Success)
            {
                results.Add(new ValidationResult("Password should contain lowercase and uppercase letters, and numbers",
                    new[] {"Password"}));
            }

            if (!Role.Equals("ADMIN") && !Role.Equals("STUDENT"))
            {
                results.Add(new ValidationResult("Role can be either 'ADMIN' or 'STUDENT'", new[] {"Role"}));
            }

            return results;
        }
    }
}
