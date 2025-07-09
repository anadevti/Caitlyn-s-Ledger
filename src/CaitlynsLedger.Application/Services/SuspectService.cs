using System.Threading.Tasks;
using AutoMapper;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;
using CaitlynsLedger.Domain.Interfaces;

namespace CaitlynsLedger.Application.Services
{
    public class SuspectService
    {
        private readonly ISuspectRepository _repository;
        private readonly IMapper _mapper;

        public SuspectService(ISuspectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SuspectDTO.SuspectDto> GetByIdAsync(int id)
        {
            var suspect = await _repository.GetByIdAsync(id);
            return _mapper.Map<SuspectDTO.SuspectDto>(suspect);
        }
    }
}