using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.DAL.Models;

namespace Travel.DAL.Services
{
    public interface ITripService
    {
        Task<int> CreateTrip(Trip trip);
        Task<int> DeleteTrip(int id);
        Task<List<Trip>> GetAllTrips();
        Task<Trip> GetTripsByID(int id);
        Task<int> UpdateTrip(Trip trip);
    }
}