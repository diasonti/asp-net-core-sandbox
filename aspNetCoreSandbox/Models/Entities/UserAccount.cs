using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using aspNetCoreSandbox.Models.Entities.Utils;

namespace aspNetCoreSandbox.Models.Entities
{
    [Table("user_account")]
    public class UserAccount
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("username")] 
        public string Username { get; set; }
        
        [Column("password")] 
        public string Password { get; set; }
        
        [Column("role")] 
        public string Role { get; set; }
        
        public ICollection<UserAccountToCourseLink> CourseLinks { get; set; }

        public ICollection<Course> Courses()
        {
            return CourseLinks.Select(link => link.Course).ToList();
        }
    }
}
