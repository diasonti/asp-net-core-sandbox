using System;

namespace aspNetCoreSandbox.Models.Forms
{
    public class TodoItemForm
    {
        public long Id { get; set; }
        
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}