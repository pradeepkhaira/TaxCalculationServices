namespace TaxCommon
{
    public class ResponseModel
    {
        public string? Municipality { get; set; }
        public string? Date { get; set; }
        public string? TaxRule { get; set; }
        public decimal? TaxRate { get; set; }
    }
}
