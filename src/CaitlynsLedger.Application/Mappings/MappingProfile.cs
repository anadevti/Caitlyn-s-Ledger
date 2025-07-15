using AutoMapper;
using CaitlynsLedger.Domain.Entities;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;

namespace CaitlynsLedgerAPI.CaitlynsLedger.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamentos para Suspect
            CreateMap<Suspect, SuspectDTO.SuspectDto>();
            CreateMap<SuspectDTO.SuspectDto, Suspect>();
            
            // Mapeamentos para Case
            CreateMap<Case, CaseDTO.CaseDto>();
            CreateMap<CaseDTO.CaseDto, Case>();
            
            // Mapeamentos para Clue
            CreateMap<Clue, ClueDTO.ClueDto>();
            CreateMap<ClueDTO.ClueDto, Clue>()
                .ForMember(dest => dest.Case, opt => opt.Ignore()); // Ignora a navegação circular
        }
    }
}
