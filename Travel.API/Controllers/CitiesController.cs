using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Interfaces;
using Travel.DAL.Models;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public readonly ICityService _city;

        public CitiesController(ICityService city)
        {
            _city = city;
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCities()
        {
            var cities = await _city.GetAllCities();

            if(cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<List<City>>> GetCitiesByTrip(int tripId)
        {
            if(tripId <= 0)
            {
                return BadRequest();
            }

            var cities = await _city.GetCitiesByTrip(tripId);

            if(cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<City>> GetCityByCityId(int cityId)
        {
            if(cityId <= 0)
            {
                return BadRequest();
            }

            var city = await _city.GetCityByCity(cityId);

            if(city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCity([FromBody] City city)
        {
            if(city == null)
            {
                return BadRequest();
            }

            await _city.CreateCity(city);

            return Ok(city.Id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateCity([FromBody] City city)
        {
            if(city == null)
            {
                return BadRequest();
            }

            await _city.UpdateCity(city);

            return Ok(city.Id);
        }

        [HttpDelete("{cityId}")]
        public async Task<ActionResult<int>> DeleteCity(int cityId)
        {
            if(cityId <= 0)
            {
                return BadRequest();
            }


            await _city.DeleteCity(cityId);
            
            return Ok(0);
        }
    }
}
