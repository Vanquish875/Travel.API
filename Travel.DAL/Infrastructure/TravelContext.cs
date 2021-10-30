using Microsoft.EntityFrameworkCore;
using Travel.DAL.Models;

namespace Travel.DAL.Infrastructure
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
    }
}
