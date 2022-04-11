using TaxCommon;

namespace TaxDataAccess
{
    public class DataSeeder
    {
        public static void Initialize(TaxContext context)
        {
            if (!context.Municipalities.Any())
            {
                var Municipalitie = new List<Municipalities>()
            {
                new Municipalities {  Name = "Vilnius", RuleId = 2 },
                new Municipalities {  Name = "Kaunas", RuleId = 1 }
            };
                context.Municipalities.AddRange(Municipalitie);
                context.SaveChanges();
            }
            if (!context.DailyTaxes.Any())
            {
                var DailyTaxe = new List<DailyTax>()
              {
                new DailyTax { DailyDate=DateTime.ParseExact("2020.01.01", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture), TaxRate=decimal.Parse("0.1"), RuleId= 2 },
                new DailyTax { DailyDate=DateTime.ParseExact("2020.12.25", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture), TaxRate=decimal.Parse("0.1"), RuleId= 2}
              };
                context.DailyTaxes.AddRange(DailyTaxe);
                context.SaveChanges();
            }
            if (!context.WeeklyTaxes.Any())
            {
                var WeeklyTaxes = new List<WeeklyTax>()
              {
                new WeeklyTax {
                    WStartDate=DateTime.ParseExact("2020.01.06", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    WEndDate=DateTime.ParseExact("2020.01.12", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    TaxRate=decimal.Parse("0.1"),
                    RuleId= 1
                }
              };
                context.WeeklyTaxes.AddRange(WeeklyTaxes);
                context.SaveChanges();
            }
            if (!context.MonthlyTaxes.Any())
            {
                var MonthlyTaxes = new List<MonthlyTax>()
              {
                new MonthlyTax {
                    MStartDate=DateTime.ParseExact("2020.01.01", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    MEndDate=DateTime.ParseExact("2020.01.31", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    TaxRate=decimal.Parse("0.2"),
                    RuleId= 1
                },
                new MonthlyTax {
                    MStartDate=DateTime.ParseExact("2020.05.01", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    MEndDate=DateTime.ParseExact("2020.05.31", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    TaxRate=decimal.Parse("0.4"),
                    RuleId= 2
                }
              };
                context.MonthlyTaxes.AddRange(MonthlyTaxes);
                context.SaveChanges();
            }
            if (!context.YearlyTaxes.Any())
            {
                var YearlyTaxes = new List<YearlyTax>()
              {
                new YearlyTax {
                    YStartDate=DateTime.ParseExact("2020.01.01", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    YEndDate=DateTime.ParseExact("2020.12.31", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    TaxRate=decimal.Parse("0.3"),
                    RuleId= 1
                },
                new YearlyTax {
                    YStartDate=DateTime.ParseExact("2020.01.01", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    YEndDate=DateTime.ParseExact("2020.12.31", "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture),
                    TaxRate=decimal.Parse("0.2"),
                    RuleId= 2
                } 
                };
                context.YearlyTaxes.AddRange(YearlyTaxes);
                context.SaveChanges();
            }
        }
    }
}
