using System.Text.Json.Serialization;

namespace CaitlynsLedgerAPI.Models
{
    public class Suspect
    {
        // caracteristics of the suspect
        public int Id { get; set; } // auto-implemented property
        public string Name { get; set; }
        public string Alibi { get; set; }
        public int CaseId { get; set; }

        [JsonIgnore]
        public Case? Case { get; set; }
    }
}
