using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.City;

namespace Travel.BLL.Interfaces
{
    public interface ICityService
    {
        Task<bool> CreateCity(CreateCityDto city);
        Task<bool> DeleteCity(int cityId);
        Task<IEnumerable<GetCityDto>> GetAllCities();
        Task<IEnumerable<GetCityDto>> GetCitiesByTrip(int tripId);
        Task<GetCityDto> GetCityByCity(int cityId);
        Task<bool> UpdateCity(UpdateCityDto city);
    }
}