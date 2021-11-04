using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.DAL.Models;

namespace Travel.BLL.Interfaces
{
    public interface IFlightService
    {
        Task<int> CreateFlight(Flight flight);
        Task<int> DeleteFlight(int id);
        Task<List<Flight>> GetAllFlights();
        Task<Flight> GetFlightByFlightID(int id);
        Task<List<Flight>> GetFlightsByTrip(int id);
        Task<int> UpdateFlight(Flight flight);
    }
}