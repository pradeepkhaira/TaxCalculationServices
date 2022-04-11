using TaxCommon;

namespace TaxDataAccess
{
    public class TaxData : ITaxData
    {
        private readonly TaxContext _taxContext;
        public TaxData(TaxContext taxContext)
        {
            _taxContext = taxContext;
        }
        public int GetRule(string name)
        {
            var result = _taxContext.Municipalities.FirstOrDefault(x => x.Name == name);
            if (result == null)
                return -1;

            return result.RuleId;
        }

        public List<TaxRuleRate> GetTaxes(string day, string name, int ruleId)
        {
            List<TaxRuleRate> ruleRates = new List<TaxRuleRate>();
            DateTime date = DateTime.ParseExact(day, "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture);
            var yearly = _taxContext.YearlyTaxes.FirstOrDefault(x => x.RuleId == ruleId && (x.YStartDate <= date && x.YEndDate >= date));
            if (yearly != null)
                ruleRates.Add(new TaxRuleRate() { RuleId = ruleId, Rate = yearly.TaxRate, TaxTime = "Yearly" });

            var monthly = _taxContext.MonthlyTaxes.FirstOrDefault(x => x.RuleId == ruleId && (x.MStartDate <= date && x.MEndDate >= date));
            if (monthly != null)
                ruleRates.Add(new TaxRuleRate() { RuleId = ruleId, Rate = monthly.TaxRate, TaxTime = "Monthly" });

            var weekly = _taxContext.WeeklyTaxes.FirstOrDefault(x => x.RuleId == ruleId && (x.WStartDate <= date && x.WEndDate >= date));
            if (weekly != null)
                ruleRates.Add(new TaxRuleRate() { RuleId = ruleId, Rate = weekly.TaxRate, TaxTime = "Weekly" });

            var Daily = _taxContext.DailyTaxes.FirstOrDefault(x => x.RuleId == ruleId && x.DailyDate == date);
            if (Daily != null)
                ruleRates.Add(new TaxRuleRate() { RuleId = ruleId, Rate = Daily.TaxRate, TaxTime = "Daily" });


            return ruleRates;

        }
    }
}
