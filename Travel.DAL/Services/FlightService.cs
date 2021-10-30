using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Travel.DAL.Services
{
    public class FlightService
    {
        private readonly TravelContext _context;

        public FlightService(TravelContext context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            var flights = await _context.TravelFlights.ToListAsync();

            return flights;
        }

        public async Task<List<Flight>> GetFlightsByTrip(int id)
        {
            var flights = await _context.TravelFlights.Where(i => i.TripId == id).ToListAsync();

            return flights;
        }

        public async Task<Flight> GetFlightByFlightID(int id)
        {
            var flight = await _context.TravelFlights.Where(i => i.FlightId == id).FirstOrDefaultAsync();

            return flight;
        }

        public async Task<int> CreateFlight(Flight flight)
        {
            _context.TravelFlights.Add(flight);
            await _context.SaveChangesAsync();

            return flight.FlightId;
        }

        public async Task<int> UpdateFlight(Flight flight)
        {
            _context.TravelFlights.Update(flight);
            await _context.SaveChangesAsync();

            return flight.FlightId;
        }

        public async Task<int> DeleteFlight(int id)
        {
            var flight = await _context.TravelFlights.Where(i => i.FlightId == id).FirstOrDefaultAsync();

            if(flight == null)
            {
                return 0;
            }

            _context.TravelFlights.Remove(flight);
            await _context.SaveChangesAsync();
            
            return flight.FlightId;
        }
    }
}
