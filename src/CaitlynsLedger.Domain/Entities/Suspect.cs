namespace CaitlynsLedger.Domain.Entities
{
    public class Suspect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
    }
}

