using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudySystem.Data;
using StudySystem.Models;
using StudySystem.Repositories.Interfaces;

namespace StudySystem.Repositories
{
    public class ClassRepository : AbstractClassRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ClassRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override DbContext getDbContext()
        {
            return _dbContext;
        }

        public override DbSet<Class> getDbSet()
        {
            return _dbContext.Classes;
        }
        
        public override List<Class> FindAll()
        {
            return getDbSet()
                .Include(c => c.Tasks)
                .Include(c => c.IndividualTasks)
                .ToList();
        }

        public override Class Find(long id)
        {
            return getDbSet()
                .Include(c => c.Tasks)
                .Include(c => c.IndividualTasks)
                .Single(ua => ua.Id.Equals(id));
        }
    }
}
