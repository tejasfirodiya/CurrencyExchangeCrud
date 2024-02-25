using CurrencyExchangeCrud.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchangeCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CountryMaster> Countries { get; set; }
        public DbSet<CurrencyMaster> Currencies { get; set; }
        public DbSet<CurrencyExchangeRate> CurrencyExchangeRates { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryMaster>()
                .HasIndex(e => e.Code)
                .IsUnique();

            modelBuilder.Entity<CurrencyMaster>()
                .HasIndex(e => e.Code)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
