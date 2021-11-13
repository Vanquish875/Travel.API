using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.BLL.Dtos.Boarding;
using Travel.BLL.Interfaces;

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
        public async Task<ActionResult<IEnumerable<GetBoardingDto>>> GetAllBoardings()
        {
            var boardings = await _boarding.GetAllBoardings();

            if(boardings == null)
            {
                return NotFound();
            }

            return Ok(boardings);
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<IEnumerable<GetBoardingDto>>> GetBoardingsByCityId(int cityId)
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
        public async Task<ActionResult<GetBoardingDto>> GetBoardingByBoardingId(int boardingId)
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
        public async Task<ActionResult<bool>> CreateBoarding([FromBody] CreateBoardingDto boarding)
        {
            if(boarding == null)
            {
                return BadRequest();
            }

            await _boarding.CreateBoarding(boarding);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateBoarding([FromBody] UpdateBoardingDto boarding)
        {
            if(boarding == null)
            {
                return BadRequest();
            }

            await _boarding.UpdateBoarding(boarding);

            return Ok();
        }

        [HttpDelete("{boardingId}")]
        public async Task<ActionResult<bool>> DeleteBoarding(int boardingId)
        {
            if(boardingId <= 0)
            {
                return BadRequest();
            }


            await _boarding.DeleteBoarding(boardingId);

            return Ok();
        }
    }
}
