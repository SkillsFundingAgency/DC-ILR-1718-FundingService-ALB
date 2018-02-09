using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;
using System.Collections.Generic;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Interface
{
    public interface IPostcodeFactorsReferenceDataService
    {
        string PostcodeFactorsVersion { get; }
        Dictionary<string, List<SfaAreaCost>> SfaAreaCost { get; }
    }
}
