using System.Text.Json.Serialization;

namespace CaitlynsLedgerAPI.Models
{
    public class Suspect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alibi { get; set; }
        public int CaseId { get; set; }

        [JsonIgnore]
        public Case? Case { get; set; } // Opcional
    }
}
