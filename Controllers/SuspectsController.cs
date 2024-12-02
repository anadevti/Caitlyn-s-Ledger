using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaitlynsLedgerAPI.Data;
using CaitlynsLedgerAPI.Models;

namespace CaitlynsLedgerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuspectsController : ControllerBase
    {
        private readonly CaitlynsLedgerContext _context;

        public SuspectsController(CaitlynsLedgerContext context)
        {
            _context = context;
        }

        // GET: api/suspects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suspect>>> GetSuspects()
        {
            return await _context.Suspects.ToListAsync();
        }

        // GET: api/suspects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Suspect>> GetSuspect(int id)
        {
            var suspect = await _context.Suspects.FindAsync(id);

            if (suspect == null)
            {
                return NotFound();
            }

            return suspect;
        }
    }
}