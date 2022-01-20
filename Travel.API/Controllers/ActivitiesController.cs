using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.Activity;
using Travel.BLL.Interfaces;

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
        public async Task<ActionResult<IEnumerable<GetActivityDto>>> GetAllActivities()
        {
            var activities = await _activity.GetAllActivities();

            if(activities == null)
            {
                return NotFound();
            }

            return Ok(activities);
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<IEnumerable<GetActivityDto>>> GetActivitiesByCity(int cityId)
        {
            if(cityId <= 0)
            {
                return BadRequest("The ID needs to be correct.");
            }

            var activities = await _activity.GetActivitiesByCity(cityId);

            if(activities == null)
            {
                return NotFound();
            }

            return Ok(activities);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateActivity([FromBody] CreateActivityDto activity)
        {
            if(activity == null)
            {
                return BadRequest();
            }

            await _activity.CreateActivity(activity);
            
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateActivity([FromBody] UpdateActivityDto activity)
        {
            if(activity == null)
            {
                return BadRequest();
            }

            await _activity.UpdateActivity(activity);

            return Ok();
        }

        [HttpDelete("{activityId}")]
        public async Task<ActionResult<bool>> DeleteActivity(int activityId)
        {
            if(activityId <= 0)
            {
                return BadRequest();
            }

            await _activity.DeleteActivity(activityId);
            
            return Ok();
        }
    }
}
