using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspNetCoreSandbox.Models.Entities
{
    [Table("individual_task_grade")]
    public class IndividualTaskGrade
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Task")]
        public long? Id { get; set; }

        [Column("grade")] 
        public int? Grade { get; set; }
        
        public IndividualTask Task { get; set; }
    }
}
