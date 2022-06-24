using HikingAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;


namespace HikingAPI.Data
{
    public class HikingDbContext : DbContext
    {
        public HikingDbContext(DbContextOptions<HikingDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Hiking> Hikes { get; set; }
    }
}
