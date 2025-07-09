using System;

namespace CaitlynsLedgerAPI.CaitlynsLedger.Application;

public class SuspectDTO
{
    public class SuspectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Suspeito, Inocente, Indeterminado
        public DateTime StartDate { get; set; }
    }
}