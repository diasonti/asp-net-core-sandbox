using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudySystem.Models;

namespace StudySystem.Repositories.Interfaces
{
    public abstract class AbstractUserAccountRepository
    {
        public abstract DbContext getDbContext();
        public abstract DbSet<UserAccount> getDbSet();
        
        public virtual List<UserAccount> FindAll()
        {
            return getDbSet().ToList();
        }

        public virtual UserAccount Find(long id)
        {
            return getDbSet().Find(id);
        }

        public void Save(UserAccount entity)
        {
            if (getDbSet().Any(ua => ua.Id.Equals(entity.Id)))
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

        public void Remove(UserAccount entity)
        {
            getDbSet().Remove(entity);
            getDbContext().SaveChanges();
        }

        public abstract UserAccount FindByUsername(string username);
    }
}
