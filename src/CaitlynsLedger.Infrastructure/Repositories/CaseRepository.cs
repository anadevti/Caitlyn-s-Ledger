using CaitlynsLedger.Domain.Entities;
using CaitlynsLedger.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using CaitlynsLedgerAPI.Data;

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
                .AsNoTracking()
                .Include(c => c.Clues)
                .Include(c => c.Suspects)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            return await _context.Cases
                .AsNoTracking()
                .Include(c => c.Clues)
                .Include(c => c.Suspects)
                .ToListAsync();
        }

        public async Task AddAsync(Case caseEntity)
        {
            // Limpa o tracking para evitar conflitos
            _context.ChangeTracker.Clear();
            
            // Para novas entidades, define Id como 0
            caseEntity.Id = 0;
            
            // Inicializa IsArchived e IsClosed como false para novos casos!
            caseEntity.IsArchived = false;
            caseEntity.IsClosed = false;
            
            // Processa as Clues
            foreach (var clue in caseEntity.Clues.ToList())
            {
                if (clue.Id > 0)
                {
                    // Se a clue já existe, busca ela do banco
                    var existingClue = await _context.Clues.FindAsync(clue.Id);
                    if (existingClue != null)
                    {
                        // Remove a clue mapeada e adiciona a existente
                        caseEntity.Clues.Remove(clue);
                        caseEntity.Clues.Add(existingClue);
                    }
                }
                else
                {
                    // Nova clue
                    clue.CaseId = 0; // Será definido automaticamente
                }
            }
            
            // Processa os Suspects - apenas define ID como 0 para novos
            foreach (var suspect in caseEntity.Suspects.ToList())
            {
                if (suspect.Id > 0)
                {
                    // Se o suspect já existe, busca ele do banco
                    var existingSuspect = await _context.Suspects.FindAsync(suspect.Id);
                    if (existingSuspect != null)
                    {
                        // Remove o suspect mapeado e adiciona o existente
                        caseEntity.Suspects.Remove(suspect);
                        caseEntity.Suspects.Add(existingSuspect);
                    }
                }
                // Não precisa definir CaseId para Suspect pois não existe essa propriedade
            }
            
            await _context.Cases.AddAsync(caseEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Case caseEntity)
        {
            _context.ChangeTracker.Clear();
            _context.Cases.Update(caseEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var caseEntity = await _context.Cases.FindAsync(id);
            if (caseEntity != null)
            {
                _context.Cases.Remove(caseEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
