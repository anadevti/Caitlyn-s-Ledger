using CaitlynsLedger.Domain.Entities;

namespace CaitlynsLedger.Domain.Interfaces
{
    public interface ISuspectRepository
    {
        Task<Suspect> GetByIdAsync(int id);
        Task<IEnumerable<Suspect>> GetAllAsync();
        Task AddAsync(Suspect suspect);
        Task UpdateAsync(Suspect suspect);
        Task DeleteAsync(int id);
    }
}