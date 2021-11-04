using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.DAL.Models;

namespace Travel.BLL.Interfaces
{
    public interface ICityService
    {
        Task<int> CreateCity(City city);
        Task<int> DeleteCity(int cityId);
        Task<List<City>> GetAllCities();
        Task<List<City>> GetCitiesByTrip(int tripId);
        Task<City> GetCityByCity(int cityId);
        Task<int> UpdateCity(City city);
    }
}