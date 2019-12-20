using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudySystem.Models;

namespace StudySystem.Repositories.Interfaces
{
    public abstract class AbstractClassRepository : BaseRepository<Class>
    {
        public List<Class> FindAllWithTasks()
        {
            return getDbSet()
                .Include(c => c.Tasks)
                .Include(c => c.IndividualTasks)
                .ToList();
        }
        
        public Class FindWithTasks(long id)
        {
            return getDbSet()
                .Include(c => c.Tasks)
                .Include(c => c.IndividualTasks)
                .Single(c => c.Id.Equals(id));
        }
        
        public Class FindByTaskIdWithTasks(long id)
        {
            return getDbSet()
                .Include(c => c.Tasks)
                .Include(c => c.IndividualTasks)
                .Single(c => c.Tasks.Any(t => t.Id.Equals(id)));
        }
        
        public Class FindByIndividualTaskIdWithTasks(long id)
        {
            return getDbSet()
                .Include(c => c.Tasks)
                .Include(c => c.IndividualTasks)
                .Single(c => c.IndividualTasks.Any(t => t.Id.Equals(id)));
        }
    }
}
