using AutoMapper;
using CaitlynsLedger.Domain.Entities;
using CaitlynsLedgerAPI.CaitlynsLedger.Application;

namespace CaitlynsLedger.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamentos para Suspect
            CreateMap<Suspect, SuspectDTO.SuspectDto>();
                    //origem   // destino
            CreateMap<SuspectDTO.SuspectDto, Suspect>();
            
            // Mapeamentos para Case
            CreateMap<Case, CaseDTO.CaseDto>();
            CreateMap<CaseDTO.CaseDto, Case>();
            
            // Mapeamentos para Clue
            CreateMap<Clue, ClueDTO.ClueDto>();
            CreateMap<ClueDTO.ClueDto, Clue>();
        }
    }
} 