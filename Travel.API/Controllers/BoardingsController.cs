using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

            return boardings;
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<List<Boarding>>> GetBoardingsByCityId(int cityId)
        {
            var boardings = await _context.TravelBoardings.Where(b => b.CityId == cityId).ToListAsync();

            if(boardings == null)
            {
                return NotFound();
            }

            return boardings;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBoarding([FromBody] Boarding boarding)
        {
            _context.Add(boarding);
            await _context.SaveChangesAsync();

            return boarding.BoardingId;
        }
    }
}
