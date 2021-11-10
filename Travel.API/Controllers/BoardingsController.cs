using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Interfaces;
using Travel.DAL.Models;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardingsController : ControllerBase
    {
        private readonly IBoardingService _boarding;

        public BoardingsController(IBoardingService boarding)
        {
            _boarding = boarding;
        }

        [HttpGet]
        public async Task<ActionResult<List<Boarding>>> GetAllBoardings()
        {
            var boardings = await _boarding.GetAllBoardings();

            if(boardings == null)
            {
                return NotFound();
            }

            return Ok(boardings);
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<List<Boarding>>> GetBoardingsByCityId(int cityId)
        {
            if(cityId <= 0)
            {
                return BadRequest();
            }

            var boardings = await _boarding.GetBoardingsByCity(cityId);

            if(boardings == null)
            {
                return NotFound();
            }

            return Ok(boardings);
        }

        [HttpGet("{boardingId}")]
        public async Task<ActionResult<Boarding>> GetBoardingByBoardingId(int boardingId)
        {
            if(boardingId <= 0)
            {
                return BadRequest();
            }

            var boarding = await _boarding.GetBoardingByBoardingId(boardingId);

            if(boarding == null)
            {
                return NotFound();
            }

            return Ok(boarding);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBoarding([FromBody] Boarding boarding)
        {
            if(boarding == null)
            {
                return BadRequest();
            }

            await _boarding.CreateBoarding(boarding);

            return Ok(boarding.Id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateBoarding([FromBody] Boarding boarding)
        {
            if(boarding == null)
            {
                return BadRequest();
            }

            await _boarding.UpdateBoarding(boarding);

            return Ok(boarding.Id);
        }

        [HttpDelete("{boardingId}")]
        public async Task<ActionResult<int>> DeleteBoarding(int boardingId)
        {
            if(boardingId <= 0)
            {
                return BadRequest();
            }


            await _boarding.DeleteBoarding(boardingId);

            return Ok(0);
        }
    }
}
