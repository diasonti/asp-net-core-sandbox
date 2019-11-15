using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspNetCoreSandbox.Models.Entities
{
    [Table("task_grade")]
    public class TaskGrade
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("grade")] 
        public int Grade { get; set; }
        
        [Column("task_id"), ForeignKey("Task")]
        public long? TaskId { get; set; }
        
        public Task Task { get; set; }
    }
}
