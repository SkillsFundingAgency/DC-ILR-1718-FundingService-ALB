using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Interface
{
    public interface IPostcodeFactorsReferenceDataService
    {
        string PostcodeFactorsCurrentVersion { get; }

        Dictionary<string, List<SfaAreaCost>> SfaAreaCost { get; }
    }
}
