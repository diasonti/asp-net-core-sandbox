using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspNetCoreSandbox.Models.Entities
{
    [Table("individual_task")]
    public class IndividualTask
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Grade")]
        public long? Id { get; set; }

        [Column("text")] 
        public string Text { get; set; }

        [Column("class_id"), ForeignKey("Class")]
        public long? ClassId { get; set; }

        public Class Class { get; set; }
        
        [Column("student_id"), ForeignKey("Student")]
        public long? StudentId { get; set; }

        public Class Student { get; set; }

        public IndividualTaskGrade Grade { get; set; }
    }
}
