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
    public class CityService : ICityService
    {
        private readonly TravelContext _context;

        public CityService(TravelContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllCities()
        {
            var cities = await _context.TravelCities
                .AsNoTracking()
                .ToListAsync();

            return cities;
        }

        public async Task<List<City>> GetCitiesByTrip(int tripId)
        {
            var cities = await _context.TravelCities
                .Where(i => i.TripId == tripId)
                .AsNoTracking()
                .ToListAsync();

            return cities;
        }

        public async Task<City> GetCityByCity(int cityId)
        {
            var city = await _context.TravelCities
                .Where(i => i.CityId == cityId)
                .AsNoTracking()
                .FirstAsync();

            return city;
        }

        public async Task<int> CreateCity(City city)
        {
            _context.TravelCities.Add(city);
            await _context.SaveChangesAsync();

            return city.CityId;
        }

        public async Task<int> UpdateCity(City city)
        {
            _context.TravelCities.Update(city);
            await _context.SaveChangesAsync();

            return city.CityId;
        }

        public async Task<int> DeleteCity(int cityId)
        {
            var city = await _context.TravelCities
                .Where(i => i.CityId == cityId)
                .FirstAsync();

            _context.TravelCities.Remove(city);
            await _context.SaveChangesAsync();

            return cityId;
        }
    }
}
