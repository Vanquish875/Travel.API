using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;

namespace Travel.BLL.Services
{
    public class ActivityService : IActivityService
    {
        private readonly TravelContext _context;

        public ActivityService(TravelContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetAllActivities()
        {
            var activities = await _context.TravelActivities
                .AsNoTracking()
                .ToListAsync();

            return activities;
        }

        public async Task<List<Activity>> GetActivitiesByCity(int cityId)
        {
            var activities = await _context.TravelActivities
                .Where(i => i.CityId == cityId)
                .AsNoTracking()
                .ToListAsync();

            return activities;
        }

        public async Task<Activity> GetActivityByActivityId(int activityId)
        {
            var activity = await _context.TravelActivities
                .Where(i => i.ActivityId == activityId)
                .AsNoTracking()
                .FirstAsync();

            return activity;
        }

        public async Task<int> CreateActivity(Activity activity)
        {
            _context.TravelActivities.Add(activity);
            await _context.SaveChangesAsync();

            return activity.ActivityId;
        }

        public async Task<int> UpdateActivity(Activity activity)
        {
            _context.TravelActivities.Update(activity);
            await _context.SaveChangesAsync();

            return activity.ActivityId;
        }

        public async Task<int> DeleteActivity(int activityId)
        {
            var activity = await _context.TravelActivities
                .Where(i => i.ActivityId == activityId)
                .FirstAsync();

            _context.Remove(activity);
            await _context.SaveChangesAsync();

            return activityId;
        }
    }
}
