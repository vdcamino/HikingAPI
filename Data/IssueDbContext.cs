using HikingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HikingAPI.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            : base(options)
        {
        }
     
        public DbSet<Issue> Issues { get; set; }     
    }
}
