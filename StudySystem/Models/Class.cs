using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudySystem.Validation;

namespace StudySystem.Models
{
    [Table("class")]
    public class Class
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("topic")]
        [Required, StringLength(255)]
        public string Topic { get; set; }
        
        [Column("course_id"), ForeignKey("Course")]
        [Required, CourseId]
        public long? CourseId { get; set; }
        
        public Course Course { get; set; }
        
        [InverseProperty("Class")]
        public ICollection<Task> Tasks { get; set; }
        
        [InverseProperty("Class")]
        public ICollection<IndividualTask> IndividualTasks { get; set; }
    }
}
