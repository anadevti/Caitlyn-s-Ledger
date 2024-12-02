using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaitlynsLedgerAPI.Data;
using CaitlynsLedgerAPI.Models;

namespace CaitlynsLedgerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CluesController : ControllerBase
    {
        private readonly CaitlynsLedgerContext _context;

        public CluesController(CaitlynsLedgerContext context)
        {
            _context = context;
        }

        // GET: api/clues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clue>>> GetClues()
        {
            return await _context.Clues.ToListAsync();
        }

        // GET: api/clues/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Clue>> GetClue(int id)
        {
            var clue = await _context.Clues.FindAsync(id);

            if (clue == null)
            {
                return NotFound();
            }

            return clue;
        }

        // POST: api/clues
        [HttpPost]
        public async Task<ActionResult<Clue>> CreateClue(Clue newClue)
        {
            _context.Clues.Add(newClue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClue), new { id = newClue.Id }, newClue);
        }
    }
}