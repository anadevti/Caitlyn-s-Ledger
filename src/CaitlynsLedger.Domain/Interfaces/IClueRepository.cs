using CaitlynsLedger.Domain.Entities;

namespace CaitlynsLedger.Domain.Interfaces
{
    public interface IClueRepository
    {
        Task<Clue> GetByIdAsync(int id);
        Task<IEnumerable<Clue>> GetAllAsync();
        Task<IEnumerable<Clue>> GetByCaseIdAsync(int caseId);
        Task AddAsync(Clue clue);
        Task UpdateAsync(Clue clue);
        Task DeleteAsync(int id);
    }
}
