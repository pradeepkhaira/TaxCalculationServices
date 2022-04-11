using System.Linq;
using TaxCommon;
using TaxDataAccess;

namespace TaxBusiness
{
    public class TaxBusinessClass : ITaxBusiness
    {
        private readonly ITaxData _taxDataAccess;
        public TaxBusinessClass(ITaxData taxData)
        {
            _taxDataAccess = taxData;
        }
        public ResponseModel GetTaxDetails(RequestModel request)
        {
            var responseModel = new ResponseModel();
            if (request != null && !string.IsNullOrEmpty( request.MunicipalityName) && !string.IsNullOrEmpty(request.Day))
            {
                int ruleId = _taxDataAccess.GetRule(request.MunicipalityName);
                if (ruleId == -1)
                    return null;

                var data = _taxDataAccess.GetTaxes(request.Day, request.MunicipalityName, ruleId);
                if(data!= null && data.Any())
                {
                    if (ruleId == 1)
                    {
                        responseModel.Municipality = request.MunicipalityName;
                        responseModel.Date = request.Day;
                        responseModel.TaxRule = ruleId.ToString();
                        responseModel.TaxRate = data.Sum(x => x.Rate);
                    }
                    else
                    {
                        switch (data)
                        {
                            case var _ when data.Contains(data.FirstOrDefault(x => x.TaxTime == "Daily")):
                                SetValues("Daily",request,data, ruleId, responseModel);
                                break;
                            case var _ when data.Contains(data.FirstOrDefault(x => x.TaxTime == "Weekly")):
                                SetValues("Weekly",request, data, ruleId, responseModel);
                                break;
                            case var _ when data.Contains(data.FirstOrDefault(x => x.TaxTime == "Monthly")):
                                SetValues("Monthly",request, data, ruleId, responseModel);
                                break;
                            case var _ when data.Contains(data.FirstOrDefault(x => x.TaxTime == "Yearly")):
                                SetValues("Yearly",request, data, ruleId, responseModel);
                                break;
                            default:
                                throw new System.ArgumentException("Some error message", nameof(data));
                        }
                    }

                }

                return responseModel;
            }
            else
            {
                return null;
            }
        }

        private void SetValues(string taxType,RequestModel request,List<TaxRuleRate> data,int ruleId, ResponseModel responseModel)
        {
            responseModel.Municipality = request.MunicipalityName;
            responseModel.Date = request.Day;
            responseModel.TaxRule = ruleId.ToString();
            responseModel.TaxRate = data.FirstOrDefault(x => x.TaxTime == taxType).Rate;
        }
    }
}