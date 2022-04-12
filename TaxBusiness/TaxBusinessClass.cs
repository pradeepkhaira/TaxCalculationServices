using Microsoft.Extensions.Logging;
using System.Linq;
using TaxCommon;
using TaxDataAccess;

namespace TaxBusiness
{
    public class TaxBusinessClass : ITaxBusiness
    {
        private readonly ITaxData _taxDataAccess;
        private readonly ILogger _logger;
        public TaxBusinessClass(ITaxData taxData,ILogger<TaxBusinessClass> logger)
        {
            _taxDataAccess = taxData;
            _logger = logger;
        }
        public ResponseModel GetTaxDetails(RequestModel request)
        {
            _logger.LogInformation("GetTaxDetails Call Started at " + DateTime.UtcNow.ToString());
            try
            {
                var responseModel = new ResponseModel();
                if (request != null && !string.IsNullOrEmpty(request.MunicipalityName) && !string.IsNullOrEmpty(request.Day))
                {
                    _logger.LogInformation("Calling for GetRule() Started at " + DateTime.UtcNow.ToString());
                    int ruleId = _taxDataAccess.GetRule(request.MunicipalityName);
                    if (ruleId == -1)
                        return null;

                    _logger.LogInformation("GetTaxes Call Started at " + DateTime.UtcNow.ToString());
                    var data = _taxDataAccess.GetTaxes(request.Day, request.MunicipalityName, ruleId);
                    if (data != null && data.Any())
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
                                    SetValues("Daily", request, data, ruleId, responseModel);
                                    break;
                                case var _ when data.Contains(data.FirstOrDefault(x => x.TaxTime == "Weekly")):
                                    SetValues("Weekly", request, data, ruleId, responseModel);
                                    break;
                                case var _ when data.Contains(data.FirstOrDefault(x => x.TaxTime == "Monthly")):
                                    SetValues("Monthly", request, data, ruleId, responseModel);
                                    break;
                                case var _ when data.Contains(data.FirstOrDefault(x => x.TaxTime == "Yearly")):
                                    SetValues("Yearly", request, data, ruleId, responseModel);
                                    break;
                                default:
                                    _logger.LogError("Error in TaxBusinessClass file under Switch Case " + nameof(data) + DateTime.UtcNow.ToString());
                                    throw new System.ArgumentException("Some error message", nameof(data));
                            }
                        }

                    }
                    _logger.LogInformation("GetTaxDetails Call End at " + DateTime.UtcNow.ToString());
                    return responseModel;
                }
                else
                {
                    _logger.LogInformation("GetTaxDetails Call End with Null Data at " + DateTime.UtcNow.ToString());
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetTaxDetails " + DateTime.UtcNow.ToString()+" ...... "+ex.Message.ToString());
                return null;
            }
            
        }
        /// <summary>
        /// SetValuesS
        /// </summary>
        /// <param name="taxType"></param>
        /// <param name="request"></param>
        /// <param name="data"></param>
        /// <param name="ruleId"></param>
        /// <param name="responseModel"></param>
        private void SetValues(string taxType,RequestModel request,List<TaxRuleRate> data,int ruleId, ResponseModel responseModel)
        {
            _logger.LogInformation("SetValues() Methods Called ! " + DateTime.UtcNow.ToString());
            responseModel.Municipality = request.MunicipalityName;
            responseModel.Date = request.Day;
            responseModel.TaxRule = ruleId.ToString();
            responseModel.TaxRate = data.FirstOrDefault(x => x.TaxTime == taxType).Rate;
        }
    }
}