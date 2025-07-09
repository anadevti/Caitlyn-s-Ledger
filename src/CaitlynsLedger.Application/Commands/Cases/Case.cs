namespace CaitlynsLedgerAPI.Models
{
    public class Case
    {
        // caracteristics of the case
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Aberto, Resolvido, Não Resolvido

        public List<Clue> Clues { get; set; } = new List<Clue>();
        public List<Suspect> Suspects { get; set; } = new List<Suspect>();
    }
}