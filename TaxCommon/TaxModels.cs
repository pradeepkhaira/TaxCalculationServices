namespace TaxCommon
{
    public class TaxRuleRate
    {
        public string? TaxTime { get; set; }
        public decimal Rate { get; set; }
        public int RuleId { get; set; }

    }
    public class Municipalities
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int RuleId { get; set; }
    }
    public class DailyTax
    {
        public int Id { get; set; }
        public DateTime DailyDate { get; set; }
        public decimal TaxRate { get; set; }
        public int RuleId { get; set; }
    }
    public class WeeklyTax
    {
        public int Id { get; set; }
        public DateTime WStartDate { get; set; }
        public DateTime WEndDate { get; set; }
        public decimal TaxRate { get; set; }
        public int RuleId { get; set; }
    }
    public class MonthlyTax
    {
        public int Id { get; set; }
        public DateTime MStartDate { get; set; }
        public DateTime MEndDate { get; set; }
        public decimal TaxRate { get; set; }
        public int RuleId { get; set; }
    }
    public class YearlyTax
    {
        public int Id { get; set; }
        public DateTime YStartDate { get; set; }
        public DateTime YEndDate { get; set; }
        public decimal TaxRate { get; set; }
        public int RuleId { get; set; }
    }
}