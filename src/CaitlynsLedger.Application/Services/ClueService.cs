using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CaitlynsLedger.Domain.Entities;
using CaitlynsLedger.Domain.Interfaces;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;

namespace CaitlynsLedger.Application.Services
{
    public class ClueService
    {
        private readonly IClueRepository _repository;
        private readonly IMapper _mapper;

        public ClueService(IClueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClueDTO.ClueDto> GetByIdAsync(int id)
        {
            var clue = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClueDTO.ClueDto>(clue);
        }

        public async Task<IEnumerable<ClueDTO.ClueDto>> GetAllAsync()
        {
            var clues = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClueDTO.ClueDto>>(clues);
        }

        public async Task<IEnumerable<ClueDTO.ClueDto>> GetByCaseIdAsync(int caseId)
        {
            var clues = await _repository.GetByCaseIdAsync(caseId);
            return _mapper.Map<IEnumerable<ClueDTO.ClueDto>>(clues);
        }

        public async Task<ClueDTO.ClueDto> AddAsync(ClueDTO.ClueDto clueDto)
        {
            var clue = _mapper.Map<Clue>(clueDto);
            await _repository.AddAsync(clue);
            return _mapper.Map<ClueDTO.ClueDto>(clue);
        }

        public async Task UpdateAsync(ClueDTO.ClueDto clueDto)
        {
            var clue = _mapper.Map<Clue>(clueDto);
            await _repository.UpdateAsync(clue);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
