using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.Trip;

namespace Travel.BLL.Interfaces
{
    public interface ITripService
    {
        Task<bool> CreateTrip(CreateTripDto tripDto);
        Task<bool> DeleteTrip(int id);
        Task<IEnumerable<GetTripDto>> GetAllTrips();
        Task<GetTripDto> GetTripByID(int id);
        Task<bool> UpdateTrip(UpdateTripDto tripDto);
    }
}