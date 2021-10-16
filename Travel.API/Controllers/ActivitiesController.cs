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

            return Ok(activities);
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<List<Activity>>> GetActivitiesByCity(int cityId)
        {
            if(cityId <= 0)
            {
                return BadRequest();
            }

            var activities = await _context.TravelActivities.Where(a => a.CityId == cityId).ToListAsync();

            if(activities == null)
            {
                return NotFound();
            }

            return Ok(activities);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateActivity([FromBody] Activity activity)
        {
            if(activity == null)
            {
                return BadRequest();
            }

            _context.TravelActivities.Add(activity);
            await _context.SaveChangesAsync();

            return Ok(activity.ActivityId);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateActivity([FromBody] Activity activity)
        {
            if(activity == null)
            {
                return BadRequest();
            }

            _context.TravelActivities.Update(activity);
            await _context.SaveChangesAsync();

            return Ok(activity.ActivityId);
        }

        [HttpDelete("{activityId}")]
        public async Task<ActionResult<int>> DeleteActivity(int activityId)
        {
            if(activityId <= 0)
            {
                return BadRequest();
            }

            var activity = await _context.TravelActivities.Where(i => i.ActivityId == activityId).FirstOrDefaultAsync();

            if(activity == null)
            {
                return NotFound();
            }

            _context.TravelActivities.Remove(activity);
            await _context.SaveChangesAsync();

            return Ok(0);
        }
    }
}
