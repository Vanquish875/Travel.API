using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Travel.BLL.Services
{
    public class BoardingService : IBoardingService
    {
        private readonly TravelContext _context;

        public BoardingService(TravelContext context)
        {
            _context = context;
        }

        public async Task<List<Boarding>> GetAllBoardings()
        {
            var boardings = await _context.TravelBoardings
                .AsNoTracking()
                .ToListAsync();

            return boardings;
        }

        public async Task<List<Boarding>> GetBoardingsByCity(int cityId)
        {
            var boardings = await _context.TravelBoardings
                .Where(i => i.CityId == cityId)
                .AsNoTracking()
                .ToListAsync();

            return boardings;
        }

        public async Task<Boarding> GetBoardingByBoardingId(int boardingId)
        {
            var boarding = await _context.TravelBoardings
                .Where(i => i.BoardingId == boardingId)
                .AsNoTracking()
                .FirstAsync();

            return boarding;
        }

        public async Task<int> CreateBoarding(Boarding boarding)
        {
            _context.TravelBoardings.Add(boarding);
            await _context.SaveChangesAsync();

            return boarding.BoardingId;
        }

        public async Task<int> UpdateBoarding(Boarding boarding)
        {
            _context.TravelBoardings.Update(boarding);
            await _context.SaveChangesAsync();

            return boarding.BoardingId;
        }

        public async Task<int> DeleteBoarding(int boardingId)
        {
            var boarding = await _context.TravelBoardings
                .Where(i => i.BoardingId == boardingId)
                .FirstAsync();

            _context.TravelBoardings.Remove(boarding);
            await _context.SaveChangesAsync();

            return boardingId;
        }
    }
}
