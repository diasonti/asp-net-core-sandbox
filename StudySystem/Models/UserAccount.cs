using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StudySystem.Models
{
    [Table("user_account")]
    public class UserAccount : BaseEntity
    {
        [Column("username")]
        [Required, StringLength(255)]
        public string Username { get; set; }
        
        [Column("role")]
        public string Role { get; set; }
        
        public ICollection<UserAccountToCourseLink> CourseLinks { get; set; }
    }
}
