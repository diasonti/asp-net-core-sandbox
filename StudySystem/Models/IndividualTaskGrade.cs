using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudySystem.Validation;

namespace StudySystem.Models
{
    [Table("individual_task_grade")]
    public class IndividualTaskGrade
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("grade")]
        [Required, Range(0, 100)]
        public int Grade { get; set; }
        
        [Column("task_id")]
        [Required, IndividualTaskId]
        public long TaskId { get; set; }
        
        public IndividualTask Task { get; set; }
    }
}
