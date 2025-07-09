using CaitlynsLedger.Domain.Entities;
using CaitlynsLedger.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using CaitlynsLedgerAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaitlynsLedger.Infrastructure.Repositories
{
    public class ClueRepository : IClueRepository
    {
        private readonly CaitlynsLedgerContext _context;

        public ClueRepository(CaitlynsLedgerContext context)
        {
            _context = context;
        }

        public async Task<Clue> GetByIdAsync(int id)
        {
            return await _context.Clues.FindAsync(id);
        }

        public async Task<IEnumerable<Clue>> GetAllAsync()
        {
            return await _context.Clues.ToListAsync();
        }

        public async Task<IEnumerable<Clue>> GetByCaseIdAsync(int caseId)
        {
            return await _context.Clues
                .Where(c => c.CaseId == caseId)
                .ToListAsync();
        }

        public async Task AddAsync(Clue clue)
        {
            await _context.Clues.AddAsync(clue);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Clue clue)
        {
            _context.Clues.Update(clue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var clue = await GetByIdAsync(id);
            if (clue != null)
            {
                _context.Clues.Remove(clue);
                await _context.SaveChangesAsync();
            }
        }
    }
}
