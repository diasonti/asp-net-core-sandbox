using System;
using aspNetCoreSandbox.Models.Entities;

namespace aspNetCoreSandbox.Models.Forms
{
    public class CrudItemForm
    {
        public long? Id { get; set; }
        
        public string Text { get; set; }
    }
}
