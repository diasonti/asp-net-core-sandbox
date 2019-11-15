using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspNetCoreSandbox.Models.Entities.Utils
{
    [Table("user_account_to_course_link")]
    public class UserAccountToCourseLink
    {
        [Column("user_account_id")]
        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }

        public UserAccount UserAccount { get; set; }
        
        [Column("course_id")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        
        public Course Course { get; set; }
    }
}
