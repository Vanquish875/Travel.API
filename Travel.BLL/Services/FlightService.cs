using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;
using Travel.BLL.Interfaces;

namespace Travel.BLL.Services
{
    public class FlightService : IFlightService
    {
        private readonly TravelContext _context;

        public FlightService(TravelContext context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            var flights = await _context.TravelFlights
                .AsNoTracking()
                .ToListAsync();

            return flights;
        }

        public async Task<List<Flight>> GetFlightsByTrip(int id)
        {
            var flights = await _context.TravelFlights
                .Where(i => i.TripId == id)
                .AsNoTracking()
                .ToListAsync();

            return flights;
        }

        public async Task<Flight> GetFlightByFlightID(int id)
        {
            var flight = await _context.TravelFlights
                .Where(i => i.Id == id)
                .AsNoTracking()
                .FirstAsync();

            return flight;
        }

        public async Task<int> CreateFlight(Flight flight)
        {
            _context.TravelFlights.Add(flight);
            await _context.SaveChangesAsync();

            return flight.Id;
        }

        public async Task<int> UpdateFlight(Flight flight)
        {
            _context.TravelFlights.Update(flight);
            await _context.SaveChangesAsync();

            return flight.Id;
        }

        public async Task<int> DeleteFlight(int id)
        {
            var flight = await _context.TravelFlights
                .Where(i => i.Id == id)
                .FirstAsync();

            if (flight == null)
            {
                return 0;
            }

            _context.TravelFlights.Remove(flight);
            await _context.SaveChangesAsync();

            return flight.Id;
        }
    }
}
