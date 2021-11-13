using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.DAL.Infrastructure;
using Travel.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Travel.BLL.Interfaces;
using Travel.BLL.Dtos.City;
using System;

namespace Travel.BLL.Services
{
    public class CityService : ICityService
    {
        private readonly TravelContext _context;

        public CityService(TravelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCityDto>> GetAllCities()
        {
            var cities = await _context.TravelCities
                .Select(i => new GetCityDto
                {
                    TripId = i.TripId,
                    CityName = i.CityName,
                    CountryName = i.CountryName,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate
                })
                .AsNoTracking()
                .ToListAsync();

            return cities;
        }

        public async Task<IEnumerable<GetCityDto>> GetCitiesByTrip(int tripId)
        {
            var cities = await _context.TravelCities
                .Where(i => i.TripId == tripId)
                .Select(i => new GetCityDto
                {
                    TripId = i.TripId,
                    CityName = i.CityName,
                    CountryName = i.CountryName,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate
                })
                .AsNoTracking()
                .ToListAsync();

            return cities;
        }

        public async Task<GetCityDto> GetCityByCity(int cityId)
        {
            var city = await _context.TravelCities
                .Where(i => i.Id == cityId)
                .Select(i => new GetCityDto
                {
                    TripId = i.TripId,
                    CityName = i.CityName,
                    CountryName = i.CountryName,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return city;
        }

        public async Task<bool> CreateCity(CreateCityDto cityDto)
        {
            if(cityDto == null)
            {
                return false;
            }

            var city = new City()
            {
                TripId = cityDto.TripId,
                CityName = cityDto.CityName,
                CountryName = cityDto.CountryName,
                StartDate = cityDto.StartDate,
                EndDate = cityDto.EndDate,
                IsDeleted = false,
                IsEnabled = true,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            _context.TravelCities.Add(city);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateCity(UpdateCityDto cityDto)
        {
            if(cityDto == null)
            {
                return false;
            }

            var city = await _context.TravelCities
                .Where(i => i.Id == cityDto.Id)
                .FirstOrDefaultAsync();

            if(city == null)
            {
                return false;
            }

            city.TripId = cityDto.TripId;
            city.CityName = cityDto.CityName;
            city.CountryName = cityDto.CountryName;
            city.StartDate = cityDto.StartDate;
            city.EndDate = cityDto.EndDate;
            city.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCity(int cityId)
        {
            var city = await _context.TravelCities
                .Where(i => i.Id == cityId)
                .FirstOrDefaultAsync();

            if(city == null)
            {
                return false;
            }

            city.IsDeleted = true;
            city.IsEnabled = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
