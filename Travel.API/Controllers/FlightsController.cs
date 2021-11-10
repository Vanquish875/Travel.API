using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Interfaces;
using Travel.DAL.Models;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flight;

        public FlightsController(IFlightService flight)
        {
            _flight = flight;
        }

        [HttpGet]
        public async Task<ActionResult<List<Flight>>> GetAllFlights()
        {
            var flights = await _flight.GetAllFlights();

            return Ok(flights);
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<List<Flight>>> GetFlightsByTrip(int tripId)
        {
            if(tripId <= 0)
            {
                return BadRequest();
            }

            var flights = await _flight.GetFlightsByTrip(tripId);

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

            var flight = await _flight.GetFlightByFlightID(flightId);

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

            await _flight.CreateFlight(flight);

            return Ok(flight.Id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateFlight([FromBody] Flight flight)
        {
            if(flight == null)
            {
                return BadRequest();
            }

            await _flight.UpdateFlight(flight);

            return Ok(flight.Id);
        }

        [HttpDelete("{flightId}")]
        public async Task<ActionResult<int>> DeleteFlight(int flightId)
        {
            if(flightId <= 0)
            {
                return BadRequest();
            }

            await _flight.DeleteFlight(flightId);

            return Ok(0);
        }
    }
}
