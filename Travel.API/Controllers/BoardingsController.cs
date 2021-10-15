using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.API.Infrastructure;
using Travel.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardingsController : ControllerBase
    {
        private readonly TravelContext _context;

        public BoardingsController(TravelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Boarding>>> GetAllBoardings()
        {
            var boardings = await _context.TravelBoardings.ToListAsync();

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

            var boardings = await _context.TravelBoardings.Where(b => b.CityId == cityId).ToListAsync();

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

            var boarding = await _context.TravelBoardings.Where(i => i.BoardingId == boardingId).FirstOrDefaultAsync();

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

            _context.Add(boarding);
            await _context.SaveChangesAsync();

            return Ok(boarding.BoardingId);
        }

        [HttpDelete("{boardingId}")]
        public async Task<ActionResult<int>> DeleteBoarding(int boardingId)
        {
            if(boardingId <= 0)
            {
                return BadRequest();
            }

            var boarding = await _context.TravelBoardings.Where(i => i.BoardingId == boardingId).FirstOrDefaultAsync();

            if(boarding == null)
            {
                return NotFound();
            }

            _context.TravelBoardings.Remove(boarding);
            await _context.SaveChangesAsync();

            return Ok(0);
        }
    }
}
