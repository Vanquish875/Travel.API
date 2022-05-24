using Microsoft.EntityFrameworkCore;
using Travel.API.Model;

namespace Travel.API.Infrastructure
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {

        }

        public DbSet<Trip> TravelTrips { get; set; }
        public DbSet<City> TravelCities { get; set; }
        public DbSet<Boarding> TravelBoardings { get; set; }
        public DbSet<Activity> TravelActivities { get; set; }
        public DbSet<Flight> TravelFlights { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Trip>()
        //        .Property(b => b.Cities)
        //        .IsRequired(false);
        //}
    }
}
