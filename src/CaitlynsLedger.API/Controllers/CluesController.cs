using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaitlynsLedger.Application.Services;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;

namespace CaitlynsLedgerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CluesController : ControllerBase
    {
        private readonly ClueService _clueService;

        public CluesController(ClueService clueService)
        {
            _clueService = clueService;
        }

        // GET: api/clues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClueDTO.ClueDto>>> GetClues()
        {
            var clues = await _clueService.GetAllAsync();
            return Ok(clues);
        }

        // GET: api/clues/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ClueDTO.ClueDto>> GetClue(int id)
        {
            var clue = await _clueService.GetByIdAsync(id);

            if (clue == null)
            {
                return NotFound();
            }

            return clue;
        }

        // POST: api/clues
        [HttpPost]
        public async Task<ActionResult<ClueDTO.ClueDto>> CreateClue(ClueDTO.ClueDto newClue)
        {
            var createdClue = await _clueService.AddAsync(newClue);
            
            return CreatedAtAction(nameof(GetClue), new { id = createdClue.Id }, createdClue);
        }
    }
}