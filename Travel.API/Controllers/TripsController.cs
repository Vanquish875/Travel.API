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
            {
                return NotFound();
            }               

            return Ok(trips);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTrip([FromBody] Trip trip)
        {
            if(trip == null)
            {
                return BadRequest();
            }

            _context.TravelTrips.Add(trip);
            await _context.SaveChangesAsync();

            return Ok(trip.TripId);
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<Trip>> GetTripByID(int tripId)
        {
            if(tripId <= 0)
            {
                return BadRequest();
            }

            var trip = await _context.TravelTrips
                .Where(t => t.TripId == tripId)
                .SingleOrDefaultAsync();

            if(trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        [HttpDelete("{tripId}")]
        public async Task<ActionResult<int>> DeleteTrip(int tripId)
        {
            if(tripId <= 0)
            {
                return BadRequest();
            }

            var trip = await _context.TravelTrips
                .Where(t => t.TripId == tripId)
                .SingleOrDefaultAsync();

            if(trip == null)
            {
                return NotFound();
            }

            _context.Remove(trip);
            await _context.SaveChangesAsync();
            
            return Ok(0);
        }
    }
}
