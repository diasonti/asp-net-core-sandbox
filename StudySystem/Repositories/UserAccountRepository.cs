using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudySystem.Data;
using StudySystem.Models;
using StudySystem.Repositories.Interfaces;

namespace StudySystem.Repositories
{
    public class UserAccountRepository : AbstractUserAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserAccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override DbContext getDbContext()
        {
            return _dbContext;
        }

        public override DbSet<UserAccount> getDbSet()
        {
            return _dbContext.UserAccounts;
        }
        
        public override List<UserAccount> FindAll()
        {
            return getDbSet()
                .Include(ua => ua.CourseLinks)
                .ToList();
        }

        public override UserAccount Find(long id)
        {
            return getDbSet()
                .Include(ua => ua.CourseLinks).ThenInclude(link => link.Course)
                .Single(ua => ua.Id.Equals(id));
        }

        public override UserAccount FindByUsername(string username)
        {
            return getDbSet()
                .Include(ua => ua.CourseLinks).ThenInclude(link => link.Course)
                .Single(ua => ua.Username.Equals(username));
        }
    }
}
