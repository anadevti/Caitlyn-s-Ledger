﻿using Microsoft.AspNetCore.Mvc;
using CaitlynsLedger.Application.Services;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;

namespace CaitlynsLedgerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuspectsController : ControllerBase
    {
        private readonly SuspectService _suspectService;

        public SuspectsController(SuspectService suspectService)
        {
            _suspectService = suspectService;
        }

        // GET: api/suspects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuspectDTO.SuspectDto>>> GetSuspects()
        {
            var suspects = await _suspectService.GetAllAsync();
            return Ok(suspects);
        }

        // GET: api/suspects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SuspectDTO.SuspectDto>> GetSuspect(int id)
        {
            var suspect = await _suspectService.GetByIdAsync(id);

            if (suspect == null)
            {
                return NotFound();
            }

            return Ok(suspect);
        }
    }
}