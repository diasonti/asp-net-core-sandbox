using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudySystem.Validation;

namespace StudySystem.Models
{
    [Table("task_grade")]
    public class TaskGrade
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("grade")]
        [Required, Range(0, 100)]
        public int Grade { get; set; }
        
        [Column("task_id"), ForeignKey("Task")]
        [Required, TaskId]
        public long? TaskId { get; set; }
        
        public Task Task { get; set; }
    }
}
