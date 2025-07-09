using CaitlynsLedger.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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
