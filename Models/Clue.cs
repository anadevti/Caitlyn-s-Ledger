using System.Text.Json.Serialization;

namespace CaitlynsLedgerAPI.Models
{
    public class Clue
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Relevance { get; set; }
        public int CaseId { get; set; }

        [JsonIgnore]
        public Case? Case { get; set; } // Opcional
    }
}
