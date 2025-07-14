using CaitlynsLedgerAPI.CaitlynsLedger.Application;

namespace CaitlynsLedger.Application.Interfaces
{
    public interface ICaseService
    {
        Task<CaseDTO.CaseDto> GetByIdAsync(int id);
        Task<IEnumerable<CaseDTO.CaseDto>> GetAllAsync();
        Task<CaseDTO.CaseDto> AddAsync(CaseDTO.CaseDto caseDto);
        Task UpdateAsync(CaseDTO.CaseDto caseDto);
        Task DeleteAsync(int id);
    }
}
