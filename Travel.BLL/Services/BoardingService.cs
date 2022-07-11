using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Travel.BLL.Interfaces;
using Travel.BLL.Dtos.Boarding;
using System;

namespace Travel.BLL.Services
{
    public class BoardingService : IBoardingService
    {
        private readonly TravelContext _context;

        public BoardingService(TravelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetBoardingDto>> GetAllBoardings()
        {
            var boardings = await _context.TravelBoardings
                .Where(i => i.IsDeleted == false)
                .Select(i => new GetBoardingDto
                {
                    Id = i.BoardingId,
                    CityId = i.CityId,
                    BoardingName = i.BoardingName,
                    Address1 = i.Address1,
                    CheckInDate = i.CheckInDate,
                    CheckOutDate = i.CheckOutDate,
                    ConfirmationCode = i.ConfirmationCode,
                    Notes = i.Notes
                })
                .AsNoTracking()
                .ToListAsync();

            return boardings;
        }

        public async Task<IEnumerable<GetBoardingDto>> GetBoardingsByCity(int cityId)
        {
            var boardings = await _context.TravelBoardings
                .Where(i => i.CityId == cityId)
                .Where(i => i.IsDeleted == false)
                .Select(i => new GetBoardingDto
                {
                    Id = i.BoardingId,
                    CityId = i.CityId,
                    BoardingName = i.BoardingName,
                    Address1 = i.Address1,
                    CheckInDate = i.CheckInDate,
                    CheckOutDate = i.CheckOutDate,
                    ConfirmationCode = i.ConfirmationCode,
                    Notes = i.Notes
                })
                .AsNoTracking()
                .ToListAsync();

            return boardings;
        }

        public async Task<GetBoardingDto> GetBoardingByBoardingId(int boardingId)
        {
            var boarding = await _context.TravelBoardings
                .Where(i => i.BoardingId == boardingId)
                .Where(i => i.IsDeleted == false)
                .Select(i => new GetBoardingDto
                {
                    Id = i.BoardingId,
                    CityId = i.CityId,
                    BoardingName = i.BoardingName,
                    Address1 = i.Address1,
                    CheckInDate = i.CheckInDate,
                    CheckOutDate = i.CheckOutDate,
                    ConfirmationCode = i.ConfirmationCode,
                    Notes = i.Notes
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return boarding;
        }

        public async Task<bool> CreateBoarding(CreateBoardingDto boardingDto)
        {
            if(boardingDto == null)
            {
                return false;
            }

            var boarding = new Boarding()
            {
                CityId = boardingDto.CityId,
                BoardingName = boardingDto.BoardingName,
                Address1 = boardingDto.Address1,
                CheckInDate = boardingDto.CheckInDate,
                CheckOutDate = boardingDto.CheckOutDate,
                ConfirmationCode = boardingDto.ConfirmationCode,
                Notes = boardingDto.Notes,
                IsDeleted = false,
                IsEnabled = true,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            _context.TravelBoardings.Add(boarding);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBoarding(UpdateBoardingDto boardingDto)
        {
            var boarding = await _context.TravelBoardings
                .FirstOrDefaultAsync();

            if(boarding == null)
            {
                return false;
            }

            boarding.CityId = boardingDto.CityId;
            boarding.BoardingName = boardingDto.BoardingName;
            boarding.Address1 = boardingDto.Address1;
            boarding.CheckInDate = boardingDto.CheckInDate;
            boarding.CheckOutDate = boardingDto.CheckOutDate;
            boarding.ConfirmationCode = boardingDto.ConfirmationCode;
            boarding.Notes = boardingDto.Notes;
            boarding.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBoarding(int boardingId)
        {
            var boarding = await _context.TravelBoardings
                .Where(i => i.BoardingId == boardingId)
                .FirstOrDefaultAsync();

            if(boarding == null)
            {
                return false;
            }

            boarding.IsDeleted = true;
            boarding.IsEnabled = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
