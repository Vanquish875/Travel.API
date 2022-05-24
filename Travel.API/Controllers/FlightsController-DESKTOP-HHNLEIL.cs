using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.API.Infrastructure;
using Travel.API.Model;
using System.Linq;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly TravelContext _context;

        public FlightsController(TravelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Flight>>> GetAllFlights()
        {
            var flights = await _context.TravelFlights.ToListAsync();

            return Ok(flights);
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByTrip(int tripId)
        {
            if(tripId <= 0)
            {
                return BadRequest();
            }

            var flights = await _context.TravelFlights.Where(i => i.TripId == tripId).ToListAsync();

            if(flights == null)
            {
                return NotFound();
            }

            return Ok(flights);
        }

        [HttpGet("{flightId}")]
        public async Task<ActionResult<Flight>> GetFlightByFlightId(int flightId)
        {
            if(flightId <= 0)
            {
                return BadRequest();
            }

            var flight = await _context.TravelFlights.Where(i => i.FlightId == flightId).FirstOrDefaultAsync();

            if(flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateFlight([FromBody] Flight flight)
        {
            if(flight == null)
            {
                return BadRequest();
            }

            _context.TravelFlights.Add(flight);
            await _context.SaveChangesAsync();

            return Ok(flight.FlightId);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateFlight([FromBody] Flight flight)
        {
            if(flight == null)
            {
                return BadRequest();
            }

            _context.TravelFlights.Add(flight);
            await _context.SaveChangesAsync();

            return Ok(flight.FlightId);
        }

        [HttpDelete("{flightId}")]
        public async Task<ActionResult<int>> DeleteFlight(int flightId)
        {
            if(flightId <= 0)
            {
                return BadRequest();
            }

            var flight = await _context.TravelFlights.Where(i => i.FlightId == flightId).FirstOrDefaultAsync();

            if(flight == null)
            {
                return NotFound();
            }

            _context.TravelFlights.Remove(flight);
            await _context.SaveChangesAsync();

            return Ok(0);
        }
    }
}
