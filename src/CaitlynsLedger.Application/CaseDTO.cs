using System;
using System.Collections.Generic;

namespace CaitlynsLedgerAPI.CaitlynsLedger.Application
{
    public class CaseDTO
    {
        public class CaseDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Status { get; set; } // Aberto, Resolvido, Não Resolvido
            public DateTime? CreatedAt { get; set; }
            public DateTime? ClosedAt { get; set; }
            
            public List<SuspectDTO.SuspectDto> Suspects { get; set; } = new List<SuspectDTO.SuspectDto>();
            public List<ClueDTO.ClueDto> Clues { get; set; } = new List<ClueDTO.ClueDto>();
        }
    }
}
