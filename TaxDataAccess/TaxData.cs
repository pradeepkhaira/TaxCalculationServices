using Microsoft.Extensions.Logging;
using TaxCommon;

namespace TaxDataAccess
{
    public class TaxData : ITaxData
    {
        private readonly TaxContext _taxContext;
        private readonly ILogger _logger;
        public TaxData(TaxContext taxContext, ILogger<TaxData> logger)
        {
            _taxContext = taxContext;
            _logger = logger;
        }
        public int GetRule(string name)
        {
            _logger.LogInformation("GetRule() Call Started at " + DateTime.UtcNow.ToString()+" Under TaxData Class !");
            var result = _taxContext.Municipalities.FirstOrDefault(x => x.Name == name);
            if (result == null)
                return -1;

            _logger.LogInformation("GetRule() Call End at " + DateTime.UtcNow.ToString() + " Under TaxData Class !");
            return result.RuleId;
        }

        public List<TaxRuleRate> GetTaxes(string day, string name, int ruleId)
        {
            try
            {
                _logger.LogInformation("GetTaxes() Call Started at " + DateTime.UtcNow.ToString() + " Under TaxData Class !");
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


                _logger.LogInformation("GetTaxes() Call End at " + DateTime.UtcNow.ToString() + " Under TaxData Class !");
                return ruleRates;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ..."+ex.Message.ToString() + DateTime.UtcNow.ToString() + " Under TaxData Class !");
                return null;
            }

        }
    }
}
