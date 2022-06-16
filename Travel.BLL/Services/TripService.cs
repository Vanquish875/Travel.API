using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;
using Travel.BLL.Interfaces;
using Travel.BLL.Dtos.Trip;
using System;

namespace Travel.BLL.Services
{
    public class TripService : ITripService
    {
        private readonly TravelContext _context;

        public TripService(TravelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetTripDto>> GetAllTrips()
        {
            var trips = await _context.TravelTrips
                .Select(i => new GetTripDto
                {
                    Id = i.TripId,
                    Name = i.Name,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate
                })
                .AsNoTracking()
                .ToListAsync();

            return trips;
        }

        public async Task<GetTripDto> GetTripByID(int id)
        {
            var trip = await _context.TravelTrips
                .Where(i => i.TripId == id)
                .Select(i => new GetTripDto
                {
                    Id = i.TripId,
                    Name = i.Name,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return trip;
        }

        public async Task<bool> CreateTrip(CreateTripDto tripDto)
        {
            if(tripDto == null)
            {
                return false;
            }

            var trip = new Trip
            {
                Name = tripDto.Name,
                StartDate = tripDto.StartDate,
                EndDate = tripDto.EndDate,
                IsDeleted = false,
                IsEnabled = true,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            _context.TravelTrips.Add(trip);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateTrip(UpdateTripDto tripDto)
        {
            var trip = await _context.TravelTrips
                .Where(i => i.TripId == tripDto.Id)
                .FirstOrDefaultAsync();

            if(trip == null)
            {
                return false;
            }

            trip.Name = tripDto.Name;
            trip.StartDate = tripDto.StartDate;
            trip.EndDate = tripDto.EndDate;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTrip(int id)
        {
            var trip = await _context.TravelTrips
                .Where(i => i.TripId == id)
                .FirstOrDefaultAsync();

            if (trip == null)
            {
                return false;
            }

            trip.IsDeleted = true;
            trip.IsEnabled = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
