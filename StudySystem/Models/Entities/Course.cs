using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using StudySystem.Models.Entities.Utils;

namespace StudySystem.Models.Entities
{
    [Table("course")]
    public class Course
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("title")] public string Title { get; set; }

        public ICollection<UserAccountToCourseLink> StudentLinks { get; set; }
      
        [InverseProperty("Course")]
        public ICollection<Class> Classes { get; set; }
        
        public ICollection<UserAccount> GetStudents()
        {
            return StudentLinks.Select(link => link.UserAccount).ToList();
        }
        
        public void addStudent(UserAccount student)
        {
            if (!student.Id.HasValue || !this.Id.HasValue)
                return;
            if (StudentLinks.Any(link => link.UserAccountId == student.Id))
            {
                return;
            }
            StudentLinks.Add(new UserAccountToCourseLink(){Course = this, CourseId = this.Id.Value, UserAccount = student, UserAccountId = student.Id.Value});
        }
        
        public void removeStudent(UserAccount student)
        {
            if (!student.Id.HasValue || !this.Id.HasValue)
                return;
            foreach (var link in StudentLinks)
            {
                if (link.UserAccountId == student.Id)
                {
                    StudentLinks.Remove(link);
                    return;
                }
            }
        }
    }
}
