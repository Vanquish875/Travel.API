using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.API.Infrastructure;
using Travel.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public readonly TravelContext _context;

        public CitiesController(TravelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCities()
        {
            var cities = await _context.TravelCities.ToListAsync();

            if(cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<List<City>>> GetCitiesByTrip(int tripId)
        {
            if(tripId <= 0)
            {
                return BadRequest();
            }

            var cities = await _context.TravelCities.Where(c => c.TripId == tripId).ToListAsync();

            if(cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<City>> GetCityByCityId(int cityId)
        {
            if(cityId <= 0)
            {
                return BadRequest();
            }

            var city = await _context.TravelCities.Where(i => i.CityId == cityId).FirstOrDefaultAsync();

            if(city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCity([FromBody] City city)
        {
            if(city == null)
            {
                return BadRequest();
            }

            _context.TravelCities.Add(city);
            await _context.SaveChangesAsync();

            return Ok(city.CityId);
        }

        [HttpDelete("{cityId}")]
        public async Task<ActionResult<int>> DeleteCity(int cityId)
        {
            if(cityId <= 0)
            {
                return BadRequest();
            }

            var city = await _context.TravelCities.Where(i => i.CityId == cityId).FirstOrDefaultAsync();
            
            if(city == null)
            {
                return NotFound();
            }


            _context.TravelCities.Remove(city);
            await _context.SaveChangesAsync();
            
            return Ok(0);
        }
    }
}
