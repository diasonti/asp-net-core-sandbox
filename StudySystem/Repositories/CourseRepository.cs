using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudySystem.Data;
using StudySystem.Models;
using StudySystem.Repositories.Interfaces;

namespace StudySystem.Repositories
{
    public class CourseRepository : AbstractCourseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override DbContext getDbContext()
        {
            return _dbContext;
        }

        public override DbSet<Course> getDbSet()
        {
            return _dbContext.Courses;
        }
        
        public override List<Course> FindAll()
        {
            return getDbSet().Include(c => c.StudentLinks).ToList();
        }

        public override Course Find(long id)
        {
            return getDbSet()
                .Include(c => c.StudentLinks).ThenInclude(link => link.UserAccount)
                .Include(c => c.Classes).ThenInclude(clazz => clazz.Tasks)
                .Include(c => c.Classes).ThenInclude(clazz => clazz.IndividualTasks)
                .Single(ua => ua.Id.Equals(id));
        }
    }
}
