using System;
using aspNetCoreSandbox.Models.Entities;

namespace aspNetCoreSandbox.Models.Forms
{
    public class CrudItemForm
    {
        public long Id { get; set; }
        
        public string Text { get; set; }

        public CrudItem FormToEntity()
        {
            return Id <= 0 ? new CrudItem {Id = 0, Text = Text} : new CrudItem {Id = Id, Text = Text};
        }
    }
}
