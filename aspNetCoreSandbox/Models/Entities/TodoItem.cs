using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspNetCoreSandbox.Models.Entities
{
    [Table("todo_item")]
    public class TodoItem
    {
        [Column("id")]
        public long Id { get; set; }
        
        [Column("text")]
        public string Text { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}