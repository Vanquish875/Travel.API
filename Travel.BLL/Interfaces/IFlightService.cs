using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.Flight;

namespace Travel.BLL.Interfaces
{
    public interface IFlightService
    {
        Task<bool> CreateFlight(CreateFlightDto flight);
        Task<bool> DeleteFlight(int id);
        Task<IEnumerable<GetFlightDto>> GetAllFlights();
        Task<GetFlightDto> GetFlightByFlightID(int id);
        Task<IEnumerable<GetFlightDto>> GetFlightsByTrip(int id);
        Task<bool> UpdateFlight(UpdateFlightDto flight);
    }
}