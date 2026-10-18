using Microsoft.EntityFrameworkCore;

namespace RouteAPI_SQL_Connect.Data
{
    public class RouteDbContext : DbContext
    {
        public RouteDbContext(DbContextOptions<RouteDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Local> Locals { get; set; }
        public DbSet<SubLocal> SubLocals { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
        public DbSet<BeaconInfo> Beacons { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<PositioningLog> PositioningLogs { get; set; }
    }
}