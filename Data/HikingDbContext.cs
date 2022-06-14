using HikingAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;


namespace HikingAPI.Data
{
    public class HikingDbContext : DbContext
    {
        public HikingDbContext(DbContextOptions<HikingDbContext> options) : base(options) { }

        public DbSet<Hiking> Hikes { get; set; }
        public DbSet<Location> Locations { get; set;}

    }
}
