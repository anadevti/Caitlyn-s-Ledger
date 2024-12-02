using Microsoft.EntityFrameworkCore;
using CaitlynsLedgerAPI.Models;

namespace CaitlynsLedgerAPI.Data
{
    public class CaitlynsLedgerContext : DbContext
    {
        public CaitlynsLedgerContext(DbContextOptions<CaitlynsLedgerContext> options)
            : base(options) { }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Clue> Clues { get; set; }
        public DbSet<Suspect> Suspects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Define o SQLite como provedor de banco de dados
                optionsBuilder.UseSqlite("Data Source=CaitlynsLedger.db");
            }
        }
    }
}