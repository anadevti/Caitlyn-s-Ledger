namespace CaitlynsLedger.Domain.Entities
{
    public class Case
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Aberto, Resolvido, Não Resolvido
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public bool IsArchived { get; set; }
        public bool IsClosed { get; set; }
        
        public ICollection<Suspect> Suspects { get; set; } = new List<Suspect>();
        public ICollection<Clue> Clues { get; set; } = new List<Clue>();
    }
}
