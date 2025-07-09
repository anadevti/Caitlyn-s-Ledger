using CaitlynsLedger.Domain.Entities;
using CaitlynsLedger.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using CaitlynsLedgerAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaitlynsLedger.Infrastructure.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly CaitlynsLedgerContext _context;

        public CaseRepository(CaitlynsLedgerContext context)
        {
            _context = context;
        }

        public async Task<Case> GetByIdAsync(int id)
        {
            return await _context.Cases
                .Include(c => c.Clues)
                .Include(c => c.Suspects)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            return await _context.Cases
                .Include(c => c.Clues)
                .Include(c => c.Suspects)
                .ToListAsync();
        }

        public async Task AddAsync(Case caseEntity)
        {
            await _context.Cases.AddAsync(caseEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Case caseEntity)
        {
            _context.Cases.Update(caseEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var caseEntity = await GetByIdAsync(id);
            if (caseEntity != null)
            {
                _context.Cases.Remove(caseEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
