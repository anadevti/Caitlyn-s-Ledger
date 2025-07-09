using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CaitlynsLedger.Domain.Entities;
using CaitlynsLedger.Domain.Interfaces;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;

namespace CaitlynsLedger.Application.Services
{
    public class CaseService
    {
        private readonly ICaseRepository _repository;
        private readonly IMapper _mapper;

        public CaseService(ICaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CaseDTO.CaseDto> GetByIdAsync(int id)
        {
            var caseEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CaseDTO.CaseDto>(caseEntity);
        }

        public async Task<IEnumerable<CaseDTO.CaseDto>> GetAllAsync()
        {
            var cases = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CaseDTO.CaseDto>>(cases);
        }

        public async Task<CaseDTO.CaseDto> AddAsync(CaseDTO.CaseDto caseDto)
        {
            var caseEntity = _mapper.Map<Case>(caseDto);
            await _repository.AddAsync(caseEntity);
            return _mapper.Map<CaseDTO.CaseDto>(caseEntity);
        }

        public async Task UpdateAsync(CaseDTO.CaseDto caseDto)
        {
            var caseEntity = _mapper.Map<Case>(caseDto);
            await _repository.UpdateAsync(caseEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
