using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Interfaces;
using Travel.DAL.Models;

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
        public async Task<ActionResult<List<Trip>>> GetAllTrips()
        {
            var trips = await _trip.GetAllTrips();

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

            await _trip.CreateTrip(trip);

            return Ok(trip.Id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateTrip([FromBody] Trip trip)
        {
            if(trip == null)
            {
                return BadRequest();
            }

            await _trip.UpdateTrip(trip);

            return Ok(trip.Id);
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<Trip>> GetTripByID(int tripId)
        {
            if(tripId <= 0)
            {
                return BadRequest();
            }

            var trip = await _trip.GetTripsByID(tripId);

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
