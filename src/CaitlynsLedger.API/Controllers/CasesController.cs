using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaitlynsLedger.Application.Services;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;

namespace CaitlynsLedgerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasesController : ControllerBase
    {
        private readonly CaseService _caseService;

        public CasesController(CaseService caseService)
        {
            _caseService = caseService;
        }

        // GET: api/cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseDTO.CaseDto>>> GetCases()
        {
            var cases = await _caseService.GetAllAsync();
            return Ok(cases);
        }
        
        // GET: api/cases/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseDTO.CaseDto>> GetCase(int id)
        {
            var caseItem = await _caseService.GetByIdAsync(id);

            if (caseItem == null)
            {
                return NotFound();
            }

            return caseItem;
        }
        
        // POST: api/cases
        [HttpPost]
        public async Task<ActionResult<CaseDTO.CaseDto>> CreateCase(CaseDTO.CaseDto newCase)
        {
            var createdCase = await _caseService.AddAsync(newCase);
            
            return CreatedAtAction(nameof(GetCase), new { id = createdCase.Id }, createdCase);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<CaseDTO.CaseDto>> DeleteCase(int id)
        {
            var caseItem = await _caseService.GetByIdAsync(id);
            if (caseItem == null)
            {
                throw new System.Exception();
            }

            await _caseService.DeleteAsync(id);
            return NoContent();
        }
        
        [HttpDelete("force-error")]
        public async Task<ActionResult<string>> ForceError()
        {
            // This endpoint is for testing error handling
            throw new System.Exception();
            return "Error forced for testing purposes.";
        }
    }
}
