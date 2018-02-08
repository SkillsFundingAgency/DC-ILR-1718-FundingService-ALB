using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Interface
{
    public interface IPostcodeFactorsReferenceDataService
    {
        string PostcodeFactorsVersion();
        Dictionary<string, List<SfaAreaCost>> SfaAreaCost();
    }
}
