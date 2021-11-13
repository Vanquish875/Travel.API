using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;
using Travel.BLL.Interfaces;
using Travel.BLL.Dtos.Activity;
using System;

namespace Travel.BLL.Services
{
    public class ActivityService : IActivityService
    {
        private readonly TravelContext _context;

        public ActivityService(TravelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetActivityDto>> GetAllActivities()
        {
            var activities = await _context.TravelActivities
                .Select(i => new GetActivityDto
                {
                    CityId = i.CityId,
                    ActivityName = i.ActivityName,
                    Address1 = i.Address1,
                    ActivityDateTime = i.ActivityDateTime,
                    CurrentActivityType = (int)i.CurrentActivityType,
                })
                .AsNoTracking()
                .ToListAsync();

            return activities;
        }

        public async Task<IEnumerable<GetActivityDto>> GetActivitiesByCity(int cityId)
        {
            var activities = await _context.TravelActivities
                .Where(i => i.CityId == cityId)
                .Select(i => new GetActivityDto
                {
                    CityId = i.CityId,
                    ActivityName = i.ActivityName,
                    Address1 = i.Address1,
                    ActivityDateTime = i.ActivityDateTime,
                    CurrentActivityType = (int)i.CurrentActivityType,
                })
                .AsNoTracking()
                .ToListAsync();

            return activities;
        }

        public async Task<GetActivityDto> GetActivityByActivityId(int activityId)
        {
            var activity = await _context.TravelActivities
                .Where(i => i.Id == activityId)
                .Select(i => new GetActivityDto
                {
                    CityId = i.CityId,
                    ActivityName = i.ActivityName,
                    Address1 = i.Address1,
                    ActivityDateTime = i.ActivityDateTime,
                    CurrentActivityType = (int)i.CurrentActivityType,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return activity;
        }

        public async Task<bool> CreateActivity(CreateActivityDto activityDto)
        {
            if(activityDto == null)
            {
                return false;
            }

            var activity = new Activity()
            {
                CityId = activityDto.CityId,
                ActivityName = activityDto.ActivityName,
                Address1 = activityDto.Address1,
                ActivityDateTime = activityDto.ActivityDateTime,
                CurrentActivityType = (Activity.ActivityType)activityDto.CurrentActivityType,
                IsDeleted = false,
                IsEnabled = true,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            _context.TravelActivities.Add(activity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateActivity(UpdateActivityDto activityDto)
        {
            var activity = await _context.TravelActivities
                .Where(i => i.Id == activityDto.Id)
                .FirstOrDefaultAsync();

            if(activity == null)
            {
                return false;
            }

            activity.CityId = activityDto.CityId;
            activity.ActivityName = activityDto.ActivityName;
            activity.Address1 = activityDto.Address1;
            activity.ActivityDateTime = activityDto.ActivityDateTime;
            activity.CurrentActivityType = (Activity.ActivityType)activityDto.CurrentActivityType;
            activity.ModifiedDate = DateTime.UtcNow;
            
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteActivity(int activityId)
        {
            var activity = await _context.TravelActivities
                .Where(i => i.Id == activityId)
                .FirstOrDefaultAsync();

            if(activity == null)
            {
                return false;
            }

            activity.IsDeleted = true;
            activity.IsEnabled = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
