using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudySystem.Models;

namespace StudySystem.Repositories.Interfaces
{
    public abstract class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        public abstract DbContext getDbContext();
        public abstract DbSet<TEntity> getDbSet();
        
        public virtual List<TEntity> FindAll()
        {
            return getDbSet().ToList();
        }

        public virtual TEntity Find(long id)
        {
            return getDbSet().Find(id);
        }

        public void Save(TEntity entity)
        {
            if (entity.Id.HasValue)
            {
                getDbSet().Update(entity);
            }
            else
            {
                getDbSet().Add(entity);
            }
            getDbContext().SaveChanges();
        }

        public void Remove(long id)
        {
            Remove(Find(id));
        }

        public void Remove(TEntity entity)
        {
            getDbSet().Remove(entity);
            getDbContext().SaveChanges();
        }

    }
}
