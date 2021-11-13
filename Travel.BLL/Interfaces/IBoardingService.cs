using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.Boarding;

namespace Travel.BLL.Interfaces
{
    public interface IBoardingService
    {
        Task<bool> CreateBoarding(CreateBoardingDto boardingDto);
        Task<bool> DeleteBoarding(int boardingId);
        Task<IEnumerable<GetBoardingDto>> GetAllBoardings();
        Task<GetBoardingDto> GetBoardingByBoardingId(int boardingId);
        Task<IEnumerable<GetBoardingDto>> GetBoardingsByCity(int cityId);
        Task<bool> UpdateBoarding(UpdateBoardingDto boarding);
    }
}