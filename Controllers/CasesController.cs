using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaitlynsLedgerAPI.Data;
using CaitlynsLedgerAPI.Models;

namespace CaitlynsLedgerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasesController : ControllerBase
    {
        private readonly CaitlynsLedgerContext _context;

        public CasesController(CaitlynsLedgerContext context)
        {
            _context = context;
        }

        // GET: api/cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Case>>> GetCases()
        {
            return await _context.Cases.Include(c => c.Clues).Include(c => c.Suspects).ToListAsync();
        }

        // GET: api/cases/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> GetCase(int id)
        {
            var caseItem = await _context.Cases.Include(c => c.Clues).Include(c => c.Suspects).FirstOrDefaultAsync(c => c.Id == id);

            if (caseItem == null)
            {
                return NotFound();
            }

            return caseItem;
        }

        // POST: api/cases
        [HttpPost]
        public async Task<ActionResult<Case>> CreateCase(Case newCase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Garante que todas as pistas e suspeitos estão corretamente associados ao caso
            foreach (var clue in newCase.Clues)
            {
                clue.CaseId = newCase.Id;
                clue.Case = null; // Garante que não há loop de referência
            }

            foreach (var suspect in newCase.Suspects)
            {
                suspect.CaseId = newCase.Id;
                suspect.Case = null; // Garante que não há loop de referência
            }

            _context.Cases.Add(newCase);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCase), new { id = newCase.Id }, newCase);
        }


        // PUT: api/cases/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCase(int id, Case updatedCase)
        {
            if (id != updatedCase.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cases.Any(c => c.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/cases/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var caseItem = await _context.Cases.FindAsync(id);
            if (caseItem == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(caseItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
