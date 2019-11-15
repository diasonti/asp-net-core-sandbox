using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using aspNetCoreSandbox.Models.Entities.Utils;

namespace aspNetCoreSandbox.Models.Entities
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
    }
}
