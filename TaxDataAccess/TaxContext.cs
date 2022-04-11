using Microsoft.EntityFrameworkCore;
using TaxCommon;

namespace TaxDataAccess
{
    public class TaxContext : DbContext
    {
        public TaxContext(DbContextOptions<TaxContext> options) : base(options) { }

        public DbSet<Municipalities> Municipalities { get; set; }
        public DbSet<DailyTax> DailyTaxes { get; set; }
        public DbSet<WeeklyTax> WeeklyTaxes { get; set; }
        public DbSet<MonthlyTax> MonthlyTaxes { get; set; }
        public DbSet<YearlyTax> YearlyTaxes { get; set; }

    }
}