using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Travel.API.Model;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly TravelContext _context;

        public ActivitiesController(TravelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetAllActivities()
        {
            var activities = await _context.TravelActivities.ToListAsync();

            if(activities == null)
            {
                return NotFound();
            }

            return activities;
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<List<Activity>>> GetActivitiesByCity(int cityId)
        {
            var activities = await _context.TravelActivities.Where(a => a.CityId == cityId).ToListAsync();

            if(activities == null)
            {
                return NotFound();
            }

            return activities;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateActivity([FromBody] Activity activity)
        {
            _context.Add(activity);
            await _context.SaveChangesAsync();

            return activity.ActivityId;
        }
    }
}
