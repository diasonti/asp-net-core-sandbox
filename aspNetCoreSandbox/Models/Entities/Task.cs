using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspNetCoreSandbox.Models.Entities
{
    [Table("task")]
    public class Task
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("text")] 
        public string Text { get; set; }
        
        [Column("class_id"), ForeignKey("Class")]
        public long? ClassId { get; set; }
        
        public Class Class { get; set; }
        
        [InverseProperty("Task")]
        public ICollection<TaskGrade> Grades { get; set; }
    }
}
