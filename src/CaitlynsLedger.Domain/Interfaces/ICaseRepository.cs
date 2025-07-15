using CaitlynsLedger.Domain.Entities;

namespace CaitlynsLedger.Domain.Interfaces
{
    public interface ICaseRepository
    {
        Task<Case> GetByIdAsync(int id);
        Task<IEnumerable<Case>> GetAllAsync();
        Task AddAsync(Case caseEntity);
        Task UpdateAsync(Case caseEntity);
        Task DeleteAsync(int id);
    }
}
