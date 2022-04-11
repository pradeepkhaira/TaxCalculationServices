using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCommon;

namespace TaxBusiness
{
    public interface ITaxBusiness
    {
        public ResponseModel GetTaxDetails(RequestModel request);
    }
}
