using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.API.Infrastructure;
using Travel.API.Model;

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

            return flights;
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByTrip(int tripId)
        {
            var flights = await _context.TravelFlights.ToListAsync();

            return flights;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateFlight([FromBody] Flight flight)
        {
            _context.TravelFlights.Add(flight);
            await _context.SaveChangesAsync();

            return flight.FlightId;
        }
    }
}
