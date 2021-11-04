using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.DAL.Models;

namespace Travel.BLL.Interfaces
{
    public interface IActivityService
    {
        Task<int> CreateActivity(Activity activity);
        Task<int> DeleteActivity(int activityId);
        Task<List<Activity>> GetActivitiesByCity(int cityId);
        Task<Activity> GetActivityByActivityId(int activityId);
        Task<List<Activity>> GetAllActivities();
        Task<int> UpdateActivity(Activity activity);
    }
}