using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;
using Travel.BLL.Interfaces;

namespace Travel.BLL.Services
{
    public class TripService : ITripService
    {
        private readonly TravelContext _context;

        public TripService(TravelContext context)
        {
            _context = context;
        }

        public async Task<List<Trip>> GetAllTrips()
        {
            var trips = await _context.TravelTrips
                .AsNoTracking()
                .ToListAsync();

            return trips;
        }

        public async Task<Trip> GetTripsByID(int id)
        {
            var trip = await _context.TravelTrips
                .Where(i => i.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return trip;
        }

        public async Task<int> CreateTrip(Trip trip)
        {
            _context.TravelTrips.Add(trip);
            await _context.SaveChangesAsync();

            return trip.Id;
        }

        public async Task<int> UpdateTrip(Trip trip)
        {
            _context.TravelTrips.Update(trip);
            await _context.SaveChangesAsync();

            return trip.Id;
        }

        public async Task<int> DeleteTrip(int id)
        {
            var trip = await _context.TravelTrips
                .Where(i => i.Id == id)
                .FirstAsync();

            if (trip == null)
            {
                return 0;
            }

            _context.TravelTrips.Remove(trip);
            await _context.SaveChangesAsync();

            return trip.Id;
        }
    }
}
