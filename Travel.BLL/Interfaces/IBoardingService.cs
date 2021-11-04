using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.DAL.Models;

namespace Travel.BLL.Interfaces
{
    public interface IBoardingService
    {
        Task<int> CreateBoarding(Boarding boarding);
        Task<int> DeleteBoarding(int boardingId);
        Task<List<Boarding>> GetAllBoardings();
        Task<Boarding> GetBoardingByBoardingId(int boardingId);
        Task<List<Boarding>> GetBoardingsByCity(int cityId);
        Task<int> UpdateBoarding(Boarding boarding);
    }
}