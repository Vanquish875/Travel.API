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

        [HttpGet("{tripId}")]
        public async Task<ActionResult<List<City>>> GetCitiesByTrip(int tripId)
        {
            var cities = await _context.TravelCities.Where(c => c.TripId == tripId).ToListAsync();

            if(cities == null)
            {
                return NotFound();
            }

            return cities;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCity([FromBody] City city)
        {
            _context.TravelCities.Add(city);
            await _context.SaveChangesAsync();

            return city.CityId;
        }
    }
}
