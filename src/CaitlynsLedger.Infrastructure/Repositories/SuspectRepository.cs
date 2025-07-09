using CaitlynsLedger.Domain.Entities;
using CaitlynsLedger.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using CaitlynsLedgerAPI.Data;

namespace CaitlynsLedger.Infrastructure.Repositories
{
    public class SuspectRepository : ISuspectRepository
    {
        private readonly CaitlynsLedgerContext _context;

        public SuspectRepository(CaitlynsLedgerContext context)
        {
            _context = context;
        }

        public async Task<Suspect> GetByIdAsync(int id)
        {
            return await _context.Suspects.FindAsync(id);
        }

        public async Task<IEnumerable<Suspect>> GetAllAsync()
        {
            return await _context.Suspects.ToListAsync();
        }

        public async Task AddAsync(Suspect suspect)
        {
            await _context.Suspects.AddAsync(suspect);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Suspect suspect)
        {
            _context.Suspects.Update(suspect);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var suspect = await GetByIdAsync(id);
            if (suspect != null)
            {
                _context.Suspects.Remove(suspect);
                await _context.SaveChangesAsync();
            }
        }
    }
}