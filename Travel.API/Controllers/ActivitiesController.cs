using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Interfaces;
using Travel.DAL.Models;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activity;

        public ActivitiesController(IActivityService activity)
        {
            _activity = activity;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetAllActivities()
        {
            var activities = await _activity.GetAllActivities();

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

            var activities = await _activity.GetActivitiesByCity(cityId);

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

            await _activity.CreateActivity(activity);
            
            return Ok(activity.Id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateActivity([FromBody] Activity activity)
        {
            if(activity == null)
            {
                return BadRequest();
            }

            await _activity.UpdateActivity(activity);

            return Ok(activity.Id);
        }

        [HttpDelete("{activityId}")]
        public async Task<ActionResult<int>> DeleteActivity(int activityId)
        {
            if(activityId <= 0)
            {
                return BadRequest();
            }

            await _activity.DeleteActivity(activityId);
            
            return Ok(0);
        }
    }
}
