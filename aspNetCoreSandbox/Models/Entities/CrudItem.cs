using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspNetCoreSandbox.Models.Entities
{
    [Table("crud_item")]
    public class CrudItem
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("text")] 
        public string Text { get; set; }
    }
}
