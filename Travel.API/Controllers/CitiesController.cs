using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.City;
using Travel.BLL.Interfaces;

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
        public async Task<ActionResult<IEnumerable<GetCityDto>>> GetAllCities()
        {
            var cities = await _city.GetAllCities();

            if(cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<IEnumerable<GetCityDto>>> GetCitiesByTrip(int tripId)
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
        public async Task<ActionResult<GetCityDto>> GetCityByCityId(int cityId)
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
        public async Task<ActionResult<bool>> CreateCity([FromBody] CreateCityDto city)
        {
            if(city == null)
            {
                return BadRequest();
            }

            await _city.CreateCity(city);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCity([FromBody] UpdateCityDto city)
        {
            if(city == null)
            {
                return BadRequest();
            }

            await _city.UpdateCity(city);

            return Ok();
        }

        [HttpDelete("{cityId}")]
        public async Task<ActionResult<bool>> DeleteCity(int cityId)
        {
            if(cityId <= 0)
            {
                return BadRequest();
            }


            await _city.DeleteCity(cityId);
            
            return Ok();
        }
    }
}
