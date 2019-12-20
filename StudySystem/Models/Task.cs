using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudySystem.Validation;

namespace StudySystem.Models
{
    [Table("task")]
    public class Task : BaseEntity
    {
        [Column("text")]
        [Required, StringLength(10000), DataType(DataType.MultilineText)]
        public string Text { get; set; }
        
        [Column("class_id"), ForeignKey("Class")]
        [Required, ClassId]
        public long ClassId { get; set; }
        
        public Class Class { get; set; }
        
        [InverseProperty("Task")]
        public ICollection<TaskGrade> Grades { get; set; }
    }
}
