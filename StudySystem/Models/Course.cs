using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudySystem.Models
{
    [Table("course")]
    public class Course : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        public ICollection<UserAccountToCourseLink> StudentLinks { get; set; }
      
        [InverseProperty("Course")]
        public ICollection<Class> Classes { get; set; }
    }
}
