using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudySystem.Models;

namespace StudySystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskGrade> TaskGrades { get; set; }
        public DbSet<IndividualTask> IndividualTasks { get; set; }
        public DbSet<IndividualTaskGrade> IndividualTaskGrades { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserAccountToCourseLink>()
                .HasKey(link => new { link.UserAccountId, link.CourseId });

            modelBuilder.Entity<UserAccountToCourseLink>()
                .HasOne(link => link.UserAccount)
                .WithMany(ua => ua.CourseLinks)
                .HasForeignKey(link => link.UserAccountId);

            modelBuilder.Entity<UserAccountToCourseLink>()
                .HasOne(link => link.Course)
                .WithMany(c => c.StudentLinks)
                .HasForeignKey(link => link.CourseId);

            modelBuilder.Entity<IndividualTask>()
                .HasOne(it => it.Grade)
                .WithOne(itg => itg.Task)
                .HasForeignKey<IndividualTaskGrade>(itg => itg.TaskId);

        }
        
        public DbSet<StudySystem.Models.UserAccountToCourseLink> UserAccountToCourseLink { get; set; }
    }
}
