using aspNetCoreSandbox.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspNetCoreSandbox.Models
{
    public class SandboxDbContext : DbContext
    {
        public SandboxDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}