using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudySystem.Models
{
    [Table("user_account")]
    public class UserAccount
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("username")] 
        public string Username { get; set; }
        
        [Column("password")] 
        public string Password { get; set; }
        
        [Column("role")] 
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
    }
}
