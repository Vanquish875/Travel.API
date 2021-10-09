using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.API.Infrastructure;
using Travel.API.Model;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly TravelContext _context;

        public TripsController(TravelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trip>>> GetAllTrips()
        {
            var trips = await _context.TravelTrips.ToListAsync();

            if (trips == null)
                return NotFound();

            return trips;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTrip([FromBody] Trip trip)
        {
            _context.TravelTrips.Add(trip);
            await _context.SaveChangesAsync();

            return trip.TripId;
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<Trip>> GetTripByID(int tripId)
        {
            var trip = await _context.TravelTrips
                .Where(t => t.TripId == tripId)
                .SingleOrDefaultAsync();

            if(trip == null)
            {
                return NotFound();
            }

            return trip;
        }

        [HttpDelete("{tripId}")]
        public async Task<ActionResult<int>> DeleteTrip(int tripId)
        {
            var trip = await _context.TravelTrips
                .Where(t => t.TripId == tripId)
                .SingleOrDefaultAsync();
            
            _context.Remove(trip);
            _context.SaveChanges();

            if(trip == null)
            {
                return NotFound();
            }

            return 0;
        }
    }
}
