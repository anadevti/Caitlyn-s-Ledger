using System;

namespace CaitlynsLedgerAPI.CaitlynsLedger.Application
{
    public class ClueDTO
    {
        public class ClueDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime DiscoveryDate { get; set; }
            public string Location { get; set; }
            public int CaseId { get; set; }
        }
    }
}
