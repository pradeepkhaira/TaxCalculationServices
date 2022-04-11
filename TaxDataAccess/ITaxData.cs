using TaxCommon;

namespace TaxDataAccess
{
    public interface ITaxData
    {
        public int GetRule(string name);
        public List<TaxRuleRate> GetTaxes(string day, string name,int ruleId);
    }
}
