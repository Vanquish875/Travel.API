using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.Activity;

namespace Travel.BLL.Interfaces
{
    public interface IActivityService
    {
        Task<bool> CreateActivity(CreateActivityDto activityDto);
        Task<bool> DeleteActivity(int activityId);
        Task<IEnumerable<GetActivityDto>> GetActivitiesByCity(int cityId);
        Task<GetActivityDto> GetActivityByActivityId(int activityId);
        Task<IEnumerable<GetActivityDto>> GetAllActivities();
        Task<bool> UpdateActivity(UpdateActivityDto activityDto);
    }
}