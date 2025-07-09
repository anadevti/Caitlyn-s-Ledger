using System;

namespace CaitlynsLedger.Domain.Entities
{
    public class Clue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DiscoveryDate { get; set; }
        public string Location { get; set; }
        public int CaseId { get; set; }
        
        public Case Case { get; set; }
    }
}
