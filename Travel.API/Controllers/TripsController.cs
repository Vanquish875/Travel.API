using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.Trip;
using Travel.BLL.Interfaces;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripService _trip;

        public TripsController(ITripService trip)
        {
            _trip = trip;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTripDto>>> GetAllTrips()
        {
            var trips = await _trip.GetAllTrips();

            if (trips == null)
            {
                return NotFound();
            }               

            return Ok(trips);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateTrip([FromBody] CreateTripDto trip)
        {
            if(trip == null)
            {
                return BadRequest();
            }

            await _trip.CreateTrip(trip);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateTrip([FromBody] UpdateTripDto trip)
        {
            if(trip == null)
            {
                return BadRequest();
            }

            await _trip.UpdateTrip(trip);

            return Ok(trip.Id);
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<GetTripDto>> GetTripByID(int tripId)
        {
            if(tripId <= 0)
            {
                return BadRequest();
            }

            var trip = await _trip.GetTripByID(tripId);

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


            await _trip.DeleteTrip(tripId);
            
            return Ok(0);
        }
    }
}
