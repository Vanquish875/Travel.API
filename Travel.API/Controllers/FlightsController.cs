using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.Flight;
using Travel.BLL.Interfaces;

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
        public async Task<ActionResult<List<GetFlightDto>>> GetAllFlights()
        {
            var flights = await _flight.GetAllFlights();

            return Ok(flights);
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<List<GetFlightDto>>> GetFlightsByTrip(int tripId)
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
        public async Task<ActionResult<GetFlightDto>> GetFlightByFlightId(int flightId)
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
        public async Task<ActionResult<bool>> CreateFlight([FromBody] CreateFlightDto flight)
        {
            if(flight == null)
            {
                return BadRequest();
            }

            await _flight.CreateFlight(flight);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateFlight([FromBody] UpdateFlightDto flight)
        {
            if(flight == null)
            {
                return BadRequest();
            }

            await _flight.UpdateFlight(flight);

            return Ok();
        }

        [HttpDelete("{flightId}")]
        public async Task<ActionResult<bool>> DeleteFlight(int flightId)
        {
            if(flightId <= 0)
            {
                return BadRequest();
            }

            await _flight.DeleteFlight(flightId);

            return Ok();
        }
    }
}
