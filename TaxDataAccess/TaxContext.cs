using Microsoft.EntityFrameworkCore;
using TaxCommon;

namespace TaxDataAccess
{
    public class TaxContext : DbContext
    {
        public TaxContext(DbContextOptions<DbContext> options) : base(options)
        {

        }
        public DbSet<Municipalities> Municipalities { get; set; }
        public DbSet<DailyTax> DailyTaxes { get; set; }
        public DbSet<WeeklyTax> WeeklyTaxes { get; set; }
        public DbSet<MonthlyTax> MonthlyTaxes { get; set; }
        public DbSet<YearlyTax> YearlyTaxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Municipalities>().HasData(
                new Municipalities
                {
                    Id = 1,
                    Name = "Vilnius",
                    RuleId = 2,
                },
                new Municipalities
                {
                    Id = 2,
                    Name = "Kaunas",
                    RuleId = 1,
                }
            );
        }
        
    }
}